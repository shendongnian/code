    SqlDataReader reader = command.ExecuteReader();    
    if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //populate fields from reader
                }
            }
            else
            {
                lbl.Text = "No records found.";
            }
    reader.Close();
    Connection.Close();
