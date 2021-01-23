    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            Product product = new Product();
            product.Name = reader["Name"].ToString();
            product.Code = reader["Code"].ToString();
            // ...
            products.Add(product);
        }
        if (reader.NextResult() && reader.Read())
        {
            int itemCount = reader.GetInt32(reader.GetOrdinal("ItemCount"));
            foreach(Product p in products)
                p.ItemCount = itemCount;
        }
    }
