        private static IEnumerable<T> GetRecords<T, TMap>(string filename)
            where T : class
            where TMap : ClassMap<T>
        {
            using (TextReader reader = File.OpenText(filename))
            {
                using (var csvReader = new CsvReader(reader))
                {
                    csvReader.Configuration.RegisterClassMap<TMap>();
                    return csvReader.GetRecords<T>();
                }
            }
        }
