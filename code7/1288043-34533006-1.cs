      using (SqlConnection con = new SqlConnection(YourConnectionString)) {
        con.Open();
        using (SqlCommand q = con.CreateCommand()) {
          q.CommandText = String.Format(
            @"select {0}
                from MyTable -- put actual table name here
               where PizzaType = @prmPizzaType", "Price2");
          q.Parameters.AddWithValue("@prmPizzaType", "Hawaiian");
          using (var reader = q.ExecuteReader()) {
            if (reader.Read()) {
              // you may want to check if value is NULL: reader.IsDBNull(0)
              Decimal value = Convert.ToDecimal(reader[0]);
              if (reader.Read()) {
                //TODO: At least 2 values: put your code here
              }
            }
            else {
              //TODO: no such value: put your code here
            }
          }
        }
      }
