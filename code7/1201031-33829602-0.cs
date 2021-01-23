    public static void DB_Select(string s, params List<string>[] lists)
    		{
    			try
    			{
    				using(var conn = new MySqlConnection(ServerConnection))
    				{
    					conn.Open();
    					MySqlCommand cmd = conn.CreateCommand();
    					cmd.CommandType = CommandType.Text;
    					string command = s;
    					cmd.CommandText = command;
    					using(var sqlreader = cmd.ExecuteReader())
    					while (sqlreader.Read())
    					{
    						if (sqlreader[0].ToString().Length > 0)
    						{
    							for (int i = 0; i < lists.Count(); i++)
    							{
    								lists[i].Add(sqlreader[i].ToString());
    							}
    						}
    						else
    						{
    							foreach (List<string> save in lists)
    							{
    								save.Add("/");
    							}
    						}
    					}
    				}
    			}
    			catch (Exception ex)
    			{
    				MessageBox.Show("Error while selecting data from database!\nDetails: " + ex);
    			}
    		}
