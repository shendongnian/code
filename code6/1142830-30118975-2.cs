    using(var connection = new OleDbConnection(conString))
    using(var command = connection.CreateCommand())
    {
       command.CommandText = "SELECT * FROM Emp WHERE emp_ID LIKE ?";
       command.Parameters.AddWithValue("?", "%" + textBox5.Text + "%");
    
       using(var reader = command.ExecuteReader())
       {
           if(reader.HasRows)
           {
               while (reader.Read())
               {
                    slip.Text = reader["emp_ID"].ToString(); 
               }
           }
           else
           {
                // Show your message box here
           }
       }
    }
