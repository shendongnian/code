     using (var connection= new SqlConnection(cs))
     {
         using (var command = new SqlCommand())
         {
             command.Connection = connection;
             connection.Open();
             command.CommandText = "SELECT * FROM ads where AdsID = @AID";
             command.Parameters.AddWithValue("@AID", your value here);
             using (var reader = command.ExecuteReader())
             {
                 int i = 0;
                 while (reader.Read())
                 {
                     //....
                 }
             }
         }
      }
