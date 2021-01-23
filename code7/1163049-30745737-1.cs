    private static Random _rand = new Random();    
    public static string GetRandomLine(string filename)
    {
    	var lines = File.ReadAllLines(filename);
    
    	var lineNumber = _rand.Next(0, lines.Length);
    
    	return lines[lineNumber];
    }
