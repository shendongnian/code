<!-- -->
    public List<MyData> ReadMyData(string path,
            string gameNameCol, string yearCol, string consoleNameCol)
    {
        using (var file = File.OpenText(path))
        using (var reader = new CsvReader(file))
        {
            reader.Configuration.RegisterClassMap(
                new MyDataClassMap(gameNameCol, yearCol, consoleNameCol));
            return reader.GetRecords<MyData>().ToList();
        }
    }
