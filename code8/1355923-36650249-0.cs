    static List<Product> GetProducts(SqlCommand command)
    {
        SqlDataReader reader = command.ExecuteReader();
        List<Product> listProducts = new List<Product>();
        while (reader.Read())
        {
            int productId = reader.GetInt32(reader.GetOrdinal("ID"));
            Product product = null;
            //check if product exists
            foreach (Product p in listProducts)
            {
               if(p.ID = productId)
                   product = p;//product already exists
            }
           
           if(product == null)
           {
              //product doesn't exist, create new
              product = new Product();
              product.ID = productId;
    
              product.Name = (!reader.IsDBNull(reader.GetOrdinal("Name")) ? (string)reader["Name"] : null);
        
              product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
              product.CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID"));
              Category newCat = new Category();
              newCat.ID = reader.GetInt32(reader.GetOrdinal("CategoryPK"));
              newCat.CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"));
              newCat.Parent = (!reader.IsDBNull(reader.GetOrdinal("ParentID")) ? reader.GetInt32(reader.GetOrdinal("ParentID")) : 0);
              product.Category = newCat;
              product.Orders = new List<Order>();
            }
            
            //add order to product
            Order order = new Order();
            order.ID = (!reader.IsDBNull(reader.GetOrdinal("OrderID")) ? (int?)reader["OrderID"] : null);
            order.ClientCompanyID = (!reader.IsDBNull(reader.GetOrdinal("ClientCompanyID")) ? (int?)reader["ClientCompanyID"] : null);
            order.ProductID = (!reader.IsDBNull(reader.GetOrdinal("ProductID")) ? (int?)reader["ProductID"] : null);
            order.Quentity = (!reader.IsDBNull(reader.GetOrdinal("Quentity")) ? (int?)reader["Quentity"] : null);
            product.Orders.Add(order);
            listProducts.Add(product);
        }
        reader.Close();
        return listProducts;
    }
