    public async void ReadFile()
    {
    	var path = @"CPU.xls";
    	var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
    
    	var file = await folder.GetFileAsync(path);
    	var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
    
    	var items = new ObservableCollection<ItemsData>();
    	
    	foreach (string line in readFile.OrderBy(line =>
    	{
    		int lineNo;
    		var success = int.TryParse(line.Split(';')[4], out lineNo);
    		if (success) return lineNo;
    		return int.MaxValue;
    	}))
    	{
    		string[] splitLines = line.Split(';');
    
    		ItemsData dataitem = new ItemsData
    		{
    			value0 = splitLines[0],
    			value1 = splitLines[1],
    			value2 = splitLines[2],
    			value3 = splitLines[3],
    			value4 = splitLines[4],
    		};
    		items.Add(dataitem);
    	}
    
    	itemsControl.DataContext = items;
    }
