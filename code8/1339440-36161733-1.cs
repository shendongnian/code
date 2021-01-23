    void DirSearch(string sDir)
    {
    	List<string> DirList = new List<string>();
    	DirList.Add("\\Combustor".ToUpper());
    	DirList.Add("\\INLET".ToUpper());
    
    	string[] extensions = { ".c", ".h", ".isi", ".isc", ".xml", ".sheet", ".txt" };
    
    	foreach (string file in Directory.EnumerateFiles(sDir, "*.*", SearchOption.AllDirectories)
    	                                 .Where(s => !DirList.Any(d => Path.GetDirectoryName(s).ToUpper().Contains(d)) && extensions.Any(ext => ext == Path.GetExtension(s))))
    	{
    		Console.WriteLine(file);
    
    	}
    }
