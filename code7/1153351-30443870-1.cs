    static void Main()
    {
        var files = Directory.GetFiles(@"C:\logs", "*.csv");
    
        foreach (var file in files)
        {
    	    using (var csv = new CsvReader(new StreamReader(file, Encoding.UTF8), true))
    		{
    			var rows = csv.Select(row => String.Join(" ", row));
                foreach (var row in rows)
                {
                    Console.WriteLine(row);
                }
    		}
        }
    }
