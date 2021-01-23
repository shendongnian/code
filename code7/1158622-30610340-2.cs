    using System;  using System.Collections.Generic;  using System.Data.Entity;  using System.Linq;  using System.Text;  using System.Threading.Tasks;  using DismedHmo.Models;  using DismedHmo.Repositories;
    namespace DismedHmo.Services {    public class ProductosService : BaseService, IProductosService
        {
    
           public ProductosService(Repository repository)
            : base(repository)
        {
        }
    
     public List<ProductosModel> GetAllProducts()
        {
            var items = Repository.Productos()
                .Include(x => x.Subcategoria)
                .ToList();
    
            return items;
        }
