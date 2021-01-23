    void WriteDictionaryToFile(Dictionary<string, string> dict, string filename)
        {
        	using (DataTable dt = new DataTable("Dict"))
        	{
        		dt.Columns.Add("Key", typeof(string));
        		dt.Columns.Add("Value", typeof(string));
        
        		foreach (var kvp in dict)
        		{
        			dt.Rows.Add(kvp.Key, kvp.Value);
        		}
        		dt.WriteXml(filename);
        	}
        	
        }
