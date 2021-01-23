    using (StreamReader sr = new StreamReader("inputFile.txt")) 
    using (StreamWriter sw = new StreamWriter("outputFile.txt"))
    {
        string line1;
        int counter = 0;
		var lineCountToGroup = 3; //change to 96
        while ((line1 = sr.ReadLine()) != null) 
        {
			var lines = new List<string>();
			lines.Add(line1);
			for(int i = 0; i < lineCountToGroup - 1; i++) //less 1 because we already added line1
				lines.Add(sr.ReadLine());
				
            var groupedLine = lines.SomeLinqIfNecessary();//whatever your grouping logic is
            sw.WriteLine(groupedLine);
        }
    }
