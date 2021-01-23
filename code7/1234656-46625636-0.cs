    public static ProductList GetProducts(string connectionString)
    {
        const string GetProductsQuery = "select ProductID, ProductName, QuantityPerUnit," +
            " UnitPrice, UnitsInStock, Products.CategoryID " +
            " from Products inner join Categories on Products.CategoryID = Categories.CategoryID " +
            " where Discontinued = 0";
    
        var products = new ProductList();
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product();
                                product.ProductID = reader.GetInt32(0);
                                product.ProductName = reader.GetString(1);
                                product.QuantityPerUnit = reader.GetString(2);
                                product.UnitPrice = reader.GetDecimal(3);
                                product.UnitsInStock = reader.GetInt16(4);
                                product.CategoryId = reader.GetInt32(5);
                                products.Add(product);
                            }
                        }
                    }
                }
            }
            return products;
        }
        catch (Exception eSql)
        {
            Debug.WriteLine("Exception: " + eSql.Message);
        }
        return null;
    }
