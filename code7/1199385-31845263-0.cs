    public static string GetData(string Table1, string Column1, string WhereColumn, string WhereValue)
    {
    	Table1 = Methods.cleaninjection(Table1); // My injection method that cleans the string
    	
        string sql = "SELECT " + Column1 + " FROM " + Table1 + " WHERE " + @WhereColumn + " =  @WhereValue";
    
    	using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
    	{
    		using (SqlCommand command = new SqlCommand(sql, connection))
    		{
    			command.Parameters.Add("@WhereValue", SqlDbType.VarChar, 50).Value = WhereValue;
    
    			connection.Open();
    
    			string veri = Convert.ToString(command.ExecuteScalar());
    			return veri;
    		}
    	}
    }
