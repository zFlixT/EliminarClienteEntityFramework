using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public NorthwindEntities contexto = new NorthwindEntities();

        public List<Categories> CargarInformacion()
        {
            var categorias = from Category in contexto.Categories
                             select Category;

            return categorias.ToList();

        }

        public int InsertarCategoria(Categories categorias)
        {
            contexto.Categories.Add(categorias);
            return contexto.SaveChanges();
        }
        public Categories ObtenerPorID(string id)
        {
            if (int.TryParse(id, out int categoryId))
            {
                // Si la conversión a entero es exitosa, realiza la consulta
                var categorias = from cm in contexto.Categories
                                 where cm.CategoryID == categoryId
                                 select cm;

                return categorias.FirstOrDefault(); // Devuelve el primer registro encontrado o null si no existe
            }
            else
            {
                // Si no es un número válido, puedes lanzar una excepción o manejarlo de alguna otra manera
                throw new FormatException("El ID proporcionado no es un número válido.");
            }
        }
        public int EliminarCategoria(string id)
        {
            var registro = ObtenerPorID(id);
            if (registro != null)
            {
                contexto.Categories.Remove(registro);
                return contexto.SaveChanges();
            }

            return 0; // Devuelve 0 si no se encontró el registro para eliminar
        }

    }
}
