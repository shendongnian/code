    DataTable dt1 = new DataTable();
    
    dt1.Columns.Add("ID1", typeof(Int32));
    dt1.Columns.Add("ID2", typeof(Int32));
    dt1.Columns.Add("Flagged", typeof(Boolean));
    dt1.Columns.Add("Att", typeof(String));
    dt1.Columns.Add("Operation", typeof(String));
    dt1.Columns.Add("Value", typeof(String));
    dt1.Columns.Add("Type", typeof(String));
    
    MySqlDataReader reader = null;
    
    using (MySqlConnection connection = new MySqlConnection("connectionstring"))
    {
    	connection.Open();
    
    	try
    	{
    
    		using (MySqlCommand command = connection.CreateCommand())
    		{
    			command.CommandType = CommandType.StoredProcedure;
    
    			command.CommandText = "viewu";
    
    			command.Parameters.AddWithValue("uname", "ausername");
    
    			reader = command.ExecuteReader(CommandBehavior.SequentialAccess);
    
    			if (reader.HasRows)
    			{
    				while (reader.Read())
    				{
    					byte[] b = null;
    
    					int ID1 = reader.GetInt32(0);
    					int ID2 = reader.GetInt32(1);
    					bool Flagged = reader.GetBoolean(2);
    					string Att = reader.GetString(3);
    					string Operation = reader.GetString(4);
    					b = (byte[])reader.GetValue(5);
    					string Type = reader.GetString(6);
    
    					string Value = Encoding.Default.GetString(b);
    
    					dt1.Rows.Add(1ID, ID2, Flagged, Attribute, Op, Value, Type);
    				}
    			}
    
    			gridControl1.DataSource = dt1;
    		}
    	}
    }
