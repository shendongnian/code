    using (TextReader reader = File.OpenText(folder))
    {
        var datesInCsv = new List<string>();
        CsvConfiguration config = new CsvConfiguration();
        config.Delimiter = ";";
        var parsedCsv = new CsvParser(reader, config);
        
        while (true)
        {
            var row = parsedCsv.Read();
            // This IsNullOrEmpty doesn't exist according 
            // to Intellisense and the compiler.
            // if(row.IsNullOrEmpty) 
            if (row == null || row.Length == 0)
            {
                // Go to the next line, don't exit.
                continue;
            }
           
            // At this point the row is an array of strings where the first
            // element is the value you are searching for. No need of loops
            Console.WriteLine(row[0]);
            Console.ReadLine(); 
        }
    }
