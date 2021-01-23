     public static IEnumerable<T> CreateSetWithValueTransfer<T>(this Table table)
        {
            var mapper = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"Value1", "Code1"},
                {"value2", "Code2"}
            };
            var set = ChangeValues(table, mapper);
            return set.CreateSet<T>();
        }
        private static Table ChangeValues(Table table, Dictionary<string, string> mapper)
        {
            var mappedTable = new Table(table.Header.ToArray());
            foreach (var row in table.Rows)
            {
                mappedTable.AddRow(row.Values.Select(x => mapper.ContainsKey(x) ? mapper[x] : x).ToArray());
            }
            return mappedTable;
        }
