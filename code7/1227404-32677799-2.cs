    public void SaveXml(int id, string xmlFileName)
    {
    	// read your XML
    	string xmlContent = File.ReadAllText(xmlFileName);
    
    	// set up query
    	string insertQuery = "INSERT INTO pages(BPMNID, XML) VALUES (@BPMNID, @XML)";
    
    	using (SqlConnection conn = new SqlConnection(-your-connection-string-here-))
    	using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
    	{
    	    // define parameters
    	    cmd.Parameters.Add("@BPMNID", SqlDbType.Int).Value = id;
    	    cmd.Parameters.Add("@XML", SqlDbType.VarChar, -1).Value = xmlContent;
    
            // open connection, execute query, close connection
        	conn.Open();
    	    cmd.ExecuteNonQuery();
    	    conn.Close();
        }
    }
