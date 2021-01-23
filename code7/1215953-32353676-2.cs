    IEnumerable<XDocument> GetDocuments(Stream bulkStream)
    {
    	const string decl = @"<?xml version='1.0' encoding='UTF-8'?>";
    	var sb = new StringBuilder();	
    	
    	bool start = true;
    	foreach(var line in GetLines(bulkStream).Where(l => !string.IsNullOrWhiteSpace(l)))
    	{
    		if (start)
    		{
    			if (line == decl)
    				start = false;
    			sb.AppendLine(line);
    		}
    		else
    		{
    			if (line == decl)
    			{
    				sb.ToString().Dump();
    				yield return XDocument.Parse(sb.ToString());
    				
    				sb.Clear();
    				start = true;
    				sb.AppendLine(line);
    			}
    			else
    				sb.AppendLine(line);
    		}
    	}
    	
    	sb.ToString().Dump();
    	yield return XDocument.Parse(sb.ToString());
    }
    
    IEnumerable<string> GetLines(Stream bulkStream)
    {
    	const string decl = @"<?xml version='1.0' encoding='UTF-8'?>";
    	var reader = new StreamReader(bulkStream);
    	string line;
    	while((line = reader.ReadLine()) != null)
    	{
    		if (line.Contains(decl))
    		{
    			var declIndex = line.IndexOf(decl);
    			yield return line.Substring(0, declIndex);
    			yield return decl;
    			yield return line.Substring(declIndex + decl.Length);
    		}
    		else
    		{
    			yield return line;
    		}
    	}
    }
 
