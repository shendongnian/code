    using(var connection = U_SQLConnection.GetConnection())
    {
       using(var command = new SqlCommand(""))
       {
         using(var reader = command.ExecuteReader())
         {
         }
       }
    }
