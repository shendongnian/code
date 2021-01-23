    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CompetitorId { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class DemoClass
    {
        public static void Demo()
        {
            var products = new List<Product>();
            // fill the list here
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(@"INSERT INTO OnlineProductsTemp$(CompetitorID, ProductCode, ProductName, Price, DateCreated)
                VALUES(@CompetitorID, @ProductCode, @ProductName, @Price, @DateCreated)", con))
                {
                    cmd.Parameters.Add("@CompetitorID", SqlDbType.Int);
                    cmd.Parameters.Add("@ProductCode", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ProductName", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime);
                    foreach (var p in products)
                    {
                        cmd.Parameters["@CompetitorID"].Value = p.CompetitorId;
                        cmd.Parameters["@ProductCode"].Value = p.Code;
                        cmd.Parameters["@ProductName"].Value = p.Name;
                        cmd.Parameters["@Price"].Value = p.Price;
                        cmd.Parameters["@DateCreated"].Value = p.DateCreated;
                        var rowsAffected = cmd.ExecuteNonQuery();
                    }
                    products.Clear();
                }
            }
        }
    }
