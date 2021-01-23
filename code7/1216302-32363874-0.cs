    // this will create a mapping from `string` to `List<string>`
    Dictionary<string, List<string>> groupedLines = lines
        .Skip(1)
        .GroupBy(line => line.Split(delimiter)[1])
        .ToDictionary(x => x.Key, x => x.ToList());
    while (!headerFileReader.EndOfStream)
    {
        headerRow = headerFileReader.ReadLine();
        List<string> itemsToProcess = null;
        if (groupedLines.TryGetValue(headerRow, out itemsToProcess))
        {
            // do stuff with itemsToProcess
        }
        else
        {
            // no such key in the dictionary
        }
    }
