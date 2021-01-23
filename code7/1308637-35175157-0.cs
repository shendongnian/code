    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        Product product = new Product();
        while (reader.Read())
        {
            product.Name = reader["Name"].ToString();
            product.Code = reader["Code"].ToString();
            // ...
        }
        products.Add(product);
        if (reader.NextResult() && reader.Read())
        {
            int itemCount = reader.GetInt32(reader.GetOrdinal("ItemCount"));
            foreach(Product p in products)
                p.ItemCount = itemCount;
        }
    }
