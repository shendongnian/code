      Action action1 = () => {
        using (SqlConnection conn = new SqlConnection(ConnectionStringHere)) {
          conn.Open();
    
          using (SqlCommand q = new SqlCommand()) {
            q.Connection = conn;
            q.CommandText = "update MyTable set x = 123 where y = 789";
    
            q.ExecuteNonQuery();
          }
        }
      };
    
      Action action2 = () => {
        using (SqlConnection conn = new SqlConnection(ConnectionStringHere)) {
          conn.Open();
    
          using (SqlCommand q = new SqlCommand()) {
            q.Connection = conn;
            q.CommandText = "delete from MyTable where y = 456";
    
            q.ExecuteNonQuery();
          }
        }
      };
    
      // Let's call both actions in parallel (simultaneously)
      Parallel.Invoke(action1, action2);
