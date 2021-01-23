    public string[] getFiles(string SourceFolder, string Filter)
    {
    	string[] MultipleFilters = Filter.Split('|');
    	
    	var SelectedFiles = Directory.GetFiles(SourceFolder)
    		.Where(f => MultipleFilters.Contains(Path.GetExtension(f).ToUpper()))
    		.Select(f => f);
    	return SelectedFiles.ToArray();
    }
