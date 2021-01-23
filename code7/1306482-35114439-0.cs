                // No row selected no delete....
               if(dataGridView1.SelectedRows.Count == 0)
               {
                   MessageBox.Show("No row selected !");// show a message here to inform
               }
                  
                // Prepare the command text with the parameter placeholder
               
               string sql = "DELETE FROM SpellingList WHERE ID = @rowID";
                // Create the connection and the command inside a using block
             using(SqlConnection myConnection = new SqlConnection("Data Source=Epic-LaptopWR;Initial Catalog=words;Integrated Security=True"))
             using (SqlCommand deleteRecord = new SqlCommand(sql, myConnection))
             {
                 myConnection.Open();
                 MessageBox.Show("The SQL Connection is Open");
                 // this overcomes  the out of bound error message 
                 // if the selectedRow is greater than 0 then exectute the code below.
                 if(dataGridView1.CurrentCell.RowIndex > 0)
                 {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    // gets the RowID from the first column in the grid
              int rowID = Convert.ToInt32(dataGridView1[0, selectedIndex].Value);
                     // Add the parameter to the command collection
              deleteRecord.Parameters.Add("@rowID", SqlDbType.Int).Value = rowID;
              deleteRecord.ExecuteNonQuery();
                    // Remove the row from the grid
                    dataGridView1.Rows.RemoveAt(selectedIndex);
                 }
                 
             }
            
        }// end of delete Button 
