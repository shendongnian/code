        // Declare reader before the try block
        OleDbDataReader reader = null;
        try
        {
            conn5.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn5;
            string query = "select * from OrderDataListTable";
            command.CommandText = query;
            reader = command.ExecuteReader();
            while (reader.Read())
               {
                    datetime = reader["DateTime"].ToString();
                    datetime = datetime.Substring(3, 2);
                    if (dateString == datetime)
                    {
                    String orderNum;    
                    orderNum = reader["OrderNo"].ToString();
                    textBox3.Text = orderNum.ToString();
                    // conn5.Close();  -> remove this line
                    getOrder();
               }
           }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error" + ex);
        }
        finally 
        {
            reader.Close();
            conn5.Close();
        }
  
