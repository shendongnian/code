        public IEnumerable<dynamic> SelectDynamic()
        {
            ....
            using (var reader = (DbDataReader)cmd.ExecuteReader())
            {
                var names = Enumerable.Range(0, reader.FieldCount)
                           .Select(reader.GetName)
                           .ToList();
                foreach (var record in reader.Cast<IDataRecord>())
                {
                    var expando = new ExpandoObject() as IDictionary<string, object>;
                    foreach (var name in names)
                        expando[name] = record[name];
                    yield return expando;
                }
            }
        }
