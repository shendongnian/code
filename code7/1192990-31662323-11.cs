        public IEnumerable<Dictionary<string, object>> SelectDictionary()
        {
            ....
            using (var reader = cmd.ExecuteReader())
            {
                var names = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                foreach (IDataRecord record in reader as IEnumerable)
                    yield return names.ToDictionary(n => n, n => record[n]);
            }
        }
