        public IEnumerable<List<object>> SelectObjectArray()
        {
            ....
            using (var reader = (DbDataReader)cmd.ExecuteReader())
            {
                var indices = Enumerable.Range(0, reader.FieldCount)
                             .ToList();
                foreach (var record in reader.Cast<IDataRecord>())
                    yield return indices.Select(i => record[i]).ToList();
            }
        }
