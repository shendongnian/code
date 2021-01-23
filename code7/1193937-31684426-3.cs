    private bool ProcessSomeDataTableToXML(DataTable dataTable)
    {
    	String xmlData = ConvertDataTableToXML(dataTable);
    	var ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["yourdatabase"].ConnectionString;
    	using (SqlConnection connection = new SqlConnection(ConnString))
    	{
    		using (SqlCommand command = new SqlCommand("sp_InsertData '" + xmlData + "'", connection))
    		{
    			connection.Open();
    			try
    			{
    				command.ExecuteNonQuery();
    				fileInserted = true;
    			}
    			catch (SqlException sqlEx)
    			{
    				fileInserted = false;
    
    				Console.WriteLine(sqlEx.Message);
    			}
    		}
    	}
    	return fileInserted;
    }
    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "XMLDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            sbSQL = null;
            swSQL = null;
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
