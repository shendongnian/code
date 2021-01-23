    private static void printTownDetails(Town _town, string txtFile)
    {	
    	string[] lines = System.IO.File.ReadAllLines(txtFile);
    	_town.Name = lines[0];
    	_town.Population = line[1];
    	
    	Console.WriteLine("Town: {0}", _town.FormatMe());
    }
