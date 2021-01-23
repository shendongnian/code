    private static void RemoveSectionFromIniFile(string file, string section)
    {
    	using (var reader = File.OpenText(file))
    	{
    		using (var writer = File.CreateText(file + ".tmp"))
    		{
    			var i = false;
    			while (reader.Peek() != -1)
    			{
    				var line = reader.ReadLine();
    				if (!string.IsNullOrWhiteSpace(line))
    				{
    					if (line.StartsWith("[") && line.EndsWith("]"))
    					{
    						if (i) i = false;
    						else if (line.Substring(1, line.Length - 2).Trim() == section) i = true;
    					}
    				}
    				if (!i) writer.WriteLine(line);
    			}
    		}
    	}
    	File.Delete(file);
    	File.Move(file + ".tmp", file);
    }
