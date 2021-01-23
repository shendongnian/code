	string[] allTitles = strArr.Split(',');	//or what ever char you're using to separate the values
	int totalitems = allTitles.Length / 2;	//get Titles count
    Data[] items = new Data[totalitems];	//initialize array of data
	
	for (i = 0; i < Data.Length; i = i + 2)
    {
		//new instance of Data
		items[i] = new Data();
		
        if (allTitles[i].ToString() != "")	//get title
        {
            items[i].Title = allTitles[i];
        }
		if (allTitles[i + 1].ToString() != "")	//get date
        {
            items[i].Date = allTitles[j];
        }
    }
