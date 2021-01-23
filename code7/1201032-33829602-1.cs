    public static void DB_Update(string s)
    		{
    			try
    			{
    				using (var conn = new MySqlConnection(ServerConnection))
    				{
    					conn.Open();
    					MySqlCommand cmd = conn.CreateCommand();
    					cmd.CommandType = CommandType.Text;
    					string command = s;
    					cmd.CommandText = command;
    					int numRowsUpdated = cmd.ExecuteNonQuery();
    
    					if(numRowsUpdated < 0)
    					{
    						MessageBox.Show("Warning DB-Contact: Affected_rows < 0!");
    					}
    				}
    			}
    			catch (Exception ex)
    			{
    				MessageBox.Show(String.Format("Updating database failed!\n\nSQL: {0}\n\nERROR: {1}",s,ex.Message));
    			}
    		}
