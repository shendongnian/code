    private static List<List<DataRow>> SplitDataTable(DataTable table, int pageSize)
    {
        return
        table.AsEnumerable()
              .Select((row, index) => new { Row = row,  Index = index, })
              .GroupBy(x => x.Index / pageSize)
              .Select(x => x.Select(v => v.Row).ToList())
              .ToList();
    }
