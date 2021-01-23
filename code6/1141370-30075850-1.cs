	String line = @"Line1
        Line2
        Line3
        Line4";
	string[] lines = line.Split('\n');
	foreach(var L in lines)
	{
    	Console.Write(L);
    	Console.WriteLine(';'); // for demonstration purpose
    }
