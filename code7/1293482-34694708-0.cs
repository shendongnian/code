    using System;
    using System.Data;
    
    namespace Groups
    {
    	public class dataAccess
    	{
    		public List<string> GetComments()
    		{
    			String connString = System.Configuration.ConfigurationManager.ConnectionStrings["GroupsConnString"].ToString();
    			conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
    
    			try
    			{
    				MySql.Data.MySqlClient.MySqlDataReader reader;
    				DataTable msg = new DataTable();
    				conn.Open();
    				List<string> comments = new List<string>();
    				queryStr = "SELECT gc.* FROM app_groups.group_comments gc WHERE gc.id_group = " + id;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
    
                    msg.Load(reader = cmd.ExecuteReader());
                    foreach(DataRow dr in msg.Rows)
    				{
    					comments.Add(dr["comment"]);
    				}
                    reader.Close();
    				return comments;
    			}
    			catch (Exception ex)
    			{
    				//throw ex;
    			}
    		}
    	}
    }
    
    
