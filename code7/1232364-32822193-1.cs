    var items = System.IO.File.
    	ReadAllLines(path + "installer.ini").
    	Where(x => x.StartsWith("#product=")).
        Select(x =>x.Replace("#product=", "").Trim()).
        ToArray();
    
    ListBox2.Items.AddRange(items);
