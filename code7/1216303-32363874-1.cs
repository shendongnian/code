    // these are your unprocessed file lines
    private string[] lines;
    // this dictionary will map each `string` key to a `List<string>`
    private Dictionary<string, List<string>> groupedLines;
    
    // this is the method where you are loading your files (you didn't include it)
    void PreprocessInputData()
    {
         // you already have this part somewhere
         lines = LoadLinesFromCsv(); 
         // after loading, group the lines by `line.Split(delimiter)[1]`
         groupedLines = lines
            .Skip(1)
            .GroupBy(line => line.Split(delimiter)[1])
            .ToDictionary(x => x.Key, x => x.ToList());
    }
    private void ProcessOrders()
    {
        while (!headerFileReader.EndOfStream)
        {
            var headerRow = headerFileReader.ReadLine();
            List<string> itemsToProcess = null;
            if (groupedLines.TryGetValue(headerRow, out itemsToProcess))
            {
                // if you are here, then
                // itemsToProcess contains all lines where
                // (line.Split(delimiter)[1]) == headerRow
            }
            else
            {
                 // no such key in the dictionary
            }
        }
    }
