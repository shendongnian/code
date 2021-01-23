    void ReadDictionaryFromFile(Dictionary<string, string> dict, string filename)
    {
    	DataTable dt = new DataTable("Dict");
    	dt.Columns.Add("Key", typeof(string));
    	dt.Columns.Add("Value", typeof(string));
    
    	dt.ReadXml(filename);
    	foreach (DataRow row in dt.Rows)
    	{
    		dict[row[0].ToString()] = row[1].ToString();
    	}
    }
