<!-- -->
    public List<MyData> ReadMyData(string path)
    {
        using (var file = File.OpenText(path))
        using (var reader = new CsvReader(file))
        {
            reader.Configuration.RegisterClassMap<MyDataClassMap>();
            return reader.GetRecords<MyData>().ToList();
        }
    }
