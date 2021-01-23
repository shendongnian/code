    public class Customer
    {
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
    public List<Customer> GetCustomerData()
    {
      var list = new List<Customer>();
      string sqlQuery = "SELECT Qty, Des, Price From MyTable Where Customer = SomeCustomer"; //Change accordingly
      string connectionString = "Your Connection String";
      using (var connection = new SqlConnection(connectionString))
      {
        using (var cmd = new SqlCommand(sqlQuery, connection))
        {
          connection.Open();
          
           using (var reader = cmd.ExecuteReader())
           {
             while (reader.Read())
             {
                var c = new Customer();
                c.Quantity = Convert.ToInt32(reader["Qty"]);
                c.Description = reader["Des"].ToString();
                c.Price = Convert.ToDouble(reader["Price"]);
                list.Add(c);
              }
           }
         }
       }
       return list;
    }
