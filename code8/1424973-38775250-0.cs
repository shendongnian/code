    using (TextReader reader = File.OpenText(folder))
    {
        var datesInCsv = new List<string>();
        CsvConfiguration config = new CsvConfiguration();
        config.Delimiter = ";";
        var parsedCsv = new CsvParser(reader, config);
        
        while (true)
        {
            var row = parsedCsv.Read();
            if (row == null)
            {
                break;
            }
           
            // At this point the row is an array of string where the first
            // element is the value you are searching for. No need of loops
            Console.WriteLine(row[0]);
            Console.ReadLine(); // Stopping after first run while troubleshooting
        }
    }
