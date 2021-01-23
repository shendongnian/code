    // ExecuteNonQuery
    command.ExecuteNonQuery();
    
    // ExecuteScalar
    var value = command.ExecuteScalar() as int?;
    
    // ExecuteReader
    using(var reader = command.ExecuteReader())
         while(reader.Read())
         {
              // Access via column name.
         }
