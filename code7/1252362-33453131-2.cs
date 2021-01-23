    void ReadDictionaryFromFile<T,U>(Dictionary<T, U> dict, string filename)
    {
    	DataTable dt = new DataTable("Dict");
    	dt.Columns.Add("Key", typeof(T));
    	dt.Columns.Add("Value", typeof(U));
    
    	dt.ReadXml(filename);
    	foreach (DataRow row in dt.Rows)
    	{
    		dict[(T)row[0]] = (U)row[1];
    	}
    }
