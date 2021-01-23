    public class ProductService
    {
        public IEnumerable<Products> GetProducts(string name) 
        {
           List<Products> products = new List<Products>();
           using (SqlConnection conn = new SqlConnection(pcon.CS))
           {
              // Your code here
              // Build up the products list from the SQL data reader
           }
           return products;
        }
    }
