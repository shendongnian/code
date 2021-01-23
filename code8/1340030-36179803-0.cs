      using (var connection = new SqlConnection(connectionString)) {
        connection.Open(); 
        // command creation and execution should be within connection "using" scope
        using (var q = new SqlCommand()) {
          q.Connection = connection;
          ...
          // reader should be within command "using" scope
          using (var reader = q.ExecuteReader()) {
            ...
          }
        }  
        ...
      } // close here
