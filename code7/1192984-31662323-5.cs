        public IEnumerable<Dictionary<string, object>> SelectDictionary()
        {
            ....
            using (var reader = (DbDataReader)cmd.ExecuteReader())
            {
                var names = Enumerable.Range(0, reader.FieldCount)
                           .Select(reader.GetName)
                           .ToList();
                foreach (var record in reader.Cast<IDataRecord>())
                    yield return names.ToDictionary(n => n, n => record[n]);
            }
        }
