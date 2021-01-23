    // use IEnumerable<Product> for .net <= 4.0 and IReadOnlyCollection<Product> for .net >= 4.5
    public IReadOnlyCollection<Product> GetInfo()
    {
        using(var con = GetConnection())
        {
            var cmd = new OdbcCommand("select * FROM Products where id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", "JBE-235");
            con.Open();
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product { Id = (string) reader["id"], Name = (string) reader["name"], Price = (decimal) reader["price"] });
            }
            return products;
        }
    }
