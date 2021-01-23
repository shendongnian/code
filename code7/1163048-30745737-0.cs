    public static string GetRandomLine(string filename)
    {
    	var lines = File.ReadAllLines(filename);
    
    	var rand = new Random();
    
    	var lineNumber = rand.Next(0, lines.Length - 1);
    
    	return lines[lineNumber];
    }
