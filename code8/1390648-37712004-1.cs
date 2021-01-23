        int month = Int32.Parse(dateString.Substring(4, 2));
        //using Console.WriteLine's overload
		Console.WriteLine("month is {0:D2}", month);
        
        //using string.Format
        Console.WriteLine(string.Format("month is {0:D2}",month))
        
        //using string interpolation 
		Console.WriteLine($"month is {month:D2}");
        //using the ToString method of the int
        Console.WriteLine("month is "+ month.ToString("D2"));
