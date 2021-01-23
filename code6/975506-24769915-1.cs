     string updatequery = @"UPDATE [table] SET [Last10Attempts] = ?, 
                                               [Last10AttemptsSum] = ?,
                                               [total-question-attempts] = ?
                                  WHERE id = ?";
     using(OleDbConnection con = new OleDbConnection(.........))
     using(OleDbCommand cmd = new OleDbCommand(updatequery, con))
     {
         con.Open();
         cmd.Parameters.AddWithValue("Last10Attempts", last10attempts);
         cmd.Parameters.AddWithValue("Last10AttemptsSum", counter);
         cmd.Parameters.AddWithValue("total-question-attempts", questionattempts + 1);
         cmd.Parameters.AddWithValue("ID", currentid + 1);
         cmd.ExecuteNonQuery();
     }
