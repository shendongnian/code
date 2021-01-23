    foreach (var line in list_lines.OrderBy(line => 
    								{
    									int lineNo;
    									var success = int.TryParse(line.Split(';')[3], out lineNo);
    									if(success) return lineNo;
    									return int.MaxValue;
    								}))
    {
    	Console.WriteLine("\t" + line);
    }
