        while (reader.Read())
        {
            product.FillProduct.Add(new product
            {
                Name = reader.GetString(0),
                Price = reader.GetDecimal(1),
                Description = reader.GetString(2),
                Image = reader.GetString(3)
            });
        }
