        int month = Int32.Parse(dateString.Substring(4, 2));
		Console.WriteLine("month is {0:D2}", month);
        
        //same as using string.Format
        Console.WriteLine(string.Format("month is {0:D2}",month))
        
        //same as using string interpolation 
		Console.WriteLine($"month is {month:D2}");
