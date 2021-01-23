    using (var reader = new StreamReader(str))
    using (var csvReader = new CsvReader(reader))
    {
        csvReader.Configuration.TrimHeaders = true;
        csvReader.Configuration.TrimFields = true;
        csvReader.Configuration.IsHeaderCaseSensitive = false;
        csvReader.Configuration.IgnoreHeaderWhiteSpace = true;
        csvReader.Configuration.SkipEmptyRecords = true;
        return csvReader.GetRecords<T>().ToList();
    }
