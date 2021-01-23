    public void InsertDataToDb()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        var records = GetRecords();
    
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            StringBuilder nonQuery = new StringBuilder();
            foreach(var item in records)
            {
                nonQuery.AppendFormat("INSERT INTO TableName (param1, param2, param3) VALUES ({0}, {1}, {2});",
                    item.param1,
                    item.param2,
                    item.param3);
            }
            
            SqlCommand cmd = new SqlCommand(nonQuery.ToString());
            
            cmd.CommandType = CommandType.Text;
            
            cmd.Connection = conn;
    
            conn.Open();
            
            cmd.ExecuteNonQuery();
            
            cmd.Parameters.Clear();
            
            conn.Close();
        }
    }
