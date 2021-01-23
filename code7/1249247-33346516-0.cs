    protected void btnRemove(object sender, EventArgs e) {
      // Do not use external connection, create your own instead 
      // Put IDisposable into using
      using (SqlConnection c = new SqlConnection(YourConnectionString)) {
        c.Open();
    
        // Make SQL Readable  
        String sql =
          @"delete 
              from Car
             where CarID = @prm_CarId; -- Note ';'
            
            delete 
              from Orders 
             where OrderID = @prm_OrderId";  
    
        // Put IDisposable into using
        using (SqlCommand cmd = new SqlCommand(sql, c)) {
          // use parameters
          cmd.Parameters.AddWithValue("@prm_CarId", lstCar.SelectedValue); 
          cmd.Parameters.AddWithValue("@prm_OrderId", lstOrders.SelectedValue);    
    
          // Your error:
          // No "Async"!: wait for query completion and only then close the connection
          // ... or use await 
          cmd.ExecuteNonQuery(); 
        }
      }
    }
