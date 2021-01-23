    string brief = @"ASSIGNMENT
    In-Class Test	02/07/2014
    In-Class Test	21/04/2013";
    		
    List<string> theLines = new List<string>();		
    var lines = brief.Split('\n').Skip(1).Select (b => b.Split('\t'));
    foreach (var line in lines)
    {
    	for (int i = 0; i < line.Length; i++)
    	{
    		theLines.Add(line[i]);
    	}
    }
