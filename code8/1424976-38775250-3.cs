    using (TextReader reader = File.OpenText(folder))
    {
        var datesInCsv = new List<string>();
        CsvConfiguration config = new CsvConfiguration();
        config.Delimiter = ";";
        config.SkipEmptyRecords = true;
        var parsedCsv = new CsvParser(reader, config);
        
        string[] row = null;
        while ((row = parsedCsv.Read()) != null)
        {
            // This IsNullOrEmpty doesn't exist according 
            // to Intellisense and the compiler.
            // if(row.IsNullOrEmpty) 
           
            // At this point the row is an array of strings where the first
            // element is the value you are searching for. No need of loops
            Console.WriteLine(row[0]);
            Console.ReadLine(); 
        }
    }
