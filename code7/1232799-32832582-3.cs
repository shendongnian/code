     public class Product
     {
        public string Name { get; set; }
        public string Price { get; set; }
     }
        [HttpGet]
        public ActionResult DrawChart()
        {
            var products = new List<Product>();
            string connectionString = @"Data Source=.;Initial Catalog=TestDb;Integrated Security=True";
          
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT Name, Price FROM Product", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       products.Add(new Product{ Name = reader.GetString(0), Price = reader.GetString(1)});
                    }
                }
            }
            return View(products);
        }
    
