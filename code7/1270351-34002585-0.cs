    foreach (string d in Directory.GetFiles(targetDirectory, "*.xml", SearchOption.AllDirectories))
    {
    	String[] lines = File.ReadAllLines(d);
    	for (int i = 0; i < lines.Length; i++)
    	{
    		if (lines[i].Contains("&"))
    		{
    			lines[i] = lines[i].Replace("&", "&amp;");			                   
    		}
    	}
    	System.IO.File.WriteAllLines(d, lines);
    }
