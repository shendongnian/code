    private static IEnumerable<T> GetRecords<T, TMap>(string filename)
    {
        using (TextReader reader = File.OpenText(filename))
        {
            using(var csvReader = new CsvReader(reader)) 
            {
                csvReader.Configuration.RegisterClassMap<TMap>();
                return csvReader.GetRecords<T>().ToList();
            }
        }
    }
