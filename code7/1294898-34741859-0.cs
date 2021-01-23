    IEnumerable<string[]> data = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Select(line => line.Split('\t'))
        .Where(fields => fields.Length == 4)
        .ToList();
    DataTable table = new DataTable();
    foreach(string col in data.First())
        table.Columns.Add(col);
    foreach (string[] fields in data.Skip(1))
        table.Rows.Add(fields);
