    private void button14_Click(object sender, EventArgs e)
    {
                    System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("....");
                    
           for (int j = 0; j < items.Count; j++)
           {
                      
                  seqnumber = seqnumber + 1;
                  tmp_name = items[j];
            
                 using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand()) 
                 {
                         cmd.CommandType = System.Data.CommandType.Text;
                         cmd.CommandText = "INSERT BeaconInfo (ID, Name, RSSI) VALUES (@ID, @NAME, @RSSI)";
                         cmd.Parameters.AddWithValue("@ID", seqnumber);
                         cmd.Parameters.AddWithValue("@NAME", tmp_name);
                         cmd.Parameters.AddWithValue("@RSSI", 55);
                         cmd.Connection = sqlConnection1;
                
            
                         sqlConnection1.Open();
                         cmd.ExecuteNonQuery();
                         sqlConnection1.Close();
                 }
            }
    }
