        public IEnumerable<List<object>> SelectObjectArray()
        {
            ....
            using (var reader = cmd.ExecuteReader())
            {
                var indices = Enumerable.Range(0, reader.FieldCount).ToList();
                foreach (IDataRecord record in reader as IEnumerable)
                    yield return indices.Select(i => record[i]).ToList();
            }
        }
