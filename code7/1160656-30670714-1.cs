    void Main()
    {
	string csvFile = @"C:\Temp\TestData.csv";
        string[] lines = File.ReadAllLines(csvFile);
        var values = lines.Select(s => new { myRow = s.Split(',')});
	//and here is your collection representing results	
       List<string[]> results = new List<string[]>();
       
		foreach (var value in values)
        {
           if(value.Values.Contains("33")){
		   	results.Add(value.myRow);
		   }
        }
		
		results.Dump();
    }
