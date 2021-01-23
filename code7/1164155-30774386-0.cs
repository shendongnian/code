    try
    {	   
    	//Upload and save the file
    	string csvPath = Server.MapPath("/upload/") + Path.GetFileName(FileUpload2.PostedFile.FileName);
    	FileUpload2.SaveAs(csvPath);
    	
    	DataTable dt = new DataTable();
    	dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
    										   new DataColumn("Name", typeof(string)),
    										   new DataColumn("Country",typeof(string)) });
    	
    	foreach (string row in File.ReadAllLines(csvPath))
    	{
    		if (!string.IsNullOrEmpty(row))
    		{
    			dt.Rows.Add();
    			int i = 0;
    			foreach (string cell in row.Split(','))
    			{
    				dt.Rows[dt.Rows.Count - 1][i] = cell;
    				i++;
    			}
    		}
    	}
    	
    	string consString = ConfigurationManager.ConnectionStrings["TOP2000_IAO4B_GROEP5ConnectionString"].ConnectionString;
    	using (SqlConnection con = new SqlConnection(consString))
    	{
    		using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
    		{
    			//Set the database table name
    			sqlBulkCopy.DestinationTableName = "[Customers]";
    			con.Open();
    			sqlBulkCopy.WriteToServer(dt);
    			con.Close();
    		}
    	}	   
    	
    }
    catch(Exception ex)
    {
    	Response.Write(ex);	
    }
