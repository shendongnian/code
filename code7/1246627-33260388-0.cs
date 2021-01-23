    public void UpdateContactInDB(int IDtoUpdate, string editedColumn, string value)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand(string.format(
                     "UPDATE ContactSet SET {0} = @value WHERE Id = @ID", 
                      editedColumn), connection);
    
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@ID", IDtoUpdate);
    
                connection.Open();
                int rowsaffected = command.ExecuteNonQuery();
    
                MessageBox.Show("Rows affected: " + rowsaffected.ToString());
    
            }
        }
