	IEnumerable<ManualInputFormat> MapFileToRows(Stream input)
    {
        var csvDescriptor = new CsvFileDescription
                                {
                                    SeparatorChar = ',',
                                    FirstLineHasColumnNames = true
                                };
        var context = new CsvContext();
        return context.Read<InputFormat>(new StreamReader(input), csvDescriptor);
    }
