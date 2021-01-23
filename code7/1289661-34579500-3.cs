    // use IEnumerable<Product> for .net <= 4.0 and IReadOnlyCollection<Product> for .net >= 4.5
    public IReadOnlyCollection<Product> GetInfo()
    {
        OdbcCommand command = new OdbcCommand("select * FROM Products where id = 'JBE-235'", OdbcConn);          
        OdbcConn.Open();
        var reader = command.ExecuteReader();
        var products = new List<Product>();
        while (reader.Read())
        {
            var product = new Product();
            // reader index is the column name from query
            // You can also use column index, for example reader.GetString(0)
            product.Id = (string) reader["id"];
            product.Name = (string) reader["name"];
            product.Price = (decimal) reader["price"];
            products.Add(product);
        }
        return products;
    }
