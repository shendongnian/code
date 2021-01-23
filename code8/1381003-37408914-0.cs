    public class ProductController : ApiController
        {
        
            public List<product> GetProductByColour(int id)
            {
                var query = (from x in db.products.AsEnumerable()
                             join y in db.catagories.AsEnumerable()
                             on x.catagory_id equals y.id 
                             where x.id.Equals(id)
                             select new product
                             {
                                 id = x.id,
                                 p_name = x.p_name,
                                 price = x.price,
                                 catagory_id = y.id,
                                 brand_id = x.brand_id,
                                 display_order = y.display_order,
        
                             }).ToList();
                return query;
            }
