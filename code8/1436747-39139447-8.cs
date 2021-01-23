    public static class Exts
    {
        public static DataTable ToDataTable(this IEnumerable<Dictionary<string, object>> list)
        {
            DataTable result = new DataTable();
            if (!list.Any())
                return result;
            var columnNames = list.SelectMany(dict => dict.Keys).Distinct();
            result.Columns.AddRange(columnNames.Select(c => new DataColumn(c)).ToArray());
            foreach (var item in list)
            {
                var row = result.NewRow();
                foreach (var key in item.Keys)
                    row[key] = item[key];
                result.Rows.Add(row);
            }
            return result;
        }
    }
