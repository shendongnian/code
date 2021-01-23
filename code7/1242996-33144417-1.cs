    private void Form1_Load(object sender, EventArgs e)
    {
    		try
    		{
    			connection.Open();
    			OleDbCommand command = new OleDbCommand();
    			command.Connection = connection;
    			string query = "select ABTEILUNG from combo";
    			command.CommandText = query;
    
    			OleDbDataReader reader = command.ExecuteReader();
    			while (reader.Read())
    			{
    				Abteilung.Items.Add(reader("ABTEILUNG").ToString());
    			}
    			reader.Close(); //' Always Close ther Reader. Don't left it open
    			
    			connection2.Open();
    			command.Connection = connection2; //' Reusing Same Command Over New Connection
    			command.CommandText = "Select Field2 from Table2";
    			while (reader.Read)
    			{
    				if (!(Convert.IsDBNull(reader("Field2")))) //' Checking If Null Value is there
    				{
    					Abteilung.Items.Add(reader("Field2").ToString());
    				}
    			}
    			reader.Close();
    			
    		}
    		catch (Exception ex)
    		{
    			MessageBox.Show("Error" + ex);
    		}
    		finally
    		{
    			connection.Close();
    			connection2.Close();
    		}
    	}
