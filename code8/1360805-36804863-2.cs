     string[] files = Directory.GetFiles(@"C:\data\", "*.txt", SearchOption.AllDirectories);
    
        using(SqlBulkCopy sbc = new SqlBulkCopy(@"Server=.\SQLExpress; Database= AAA; Integrated Security=SSPI;"))
    	{
    		sbc.DestinationTableName = "dbo.textFilesCompletes";
    		sbc.EnableStreaming = true;
    		foreach(string file in files)
    		{
    			int lineNumber = 1;
    			var lines = from a in File.ReadLines(file,Encoding.Default)
    						select new {FileName = file,Text = a,LineNumber = lineNumber++};
    			sbc.WriteToServer(lines.AsDataReader() );				
    			
    		}
    	}
