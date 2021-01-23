     [WebMethod]
          
          public IEnumerable HelloWorld()
       
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["NORTHWNDConnectionString"].ToString());
            …
            IEnumerable order = (from DataRow row in dt.Rows
                                 select new Products
                                 {
                                     ProductId = Convert.ToInt32(row["ProductId"]),
                                     ProductName = row["ProductName"].ToString(),
                                     UnitPrice = Convert.ToDouble(row["UnitPrice"]),
                                     UnitsInStock = Convert.ToInt32(row["UnitsInStock"])
                                 }).ToList();
            
            
            return order;
        }
