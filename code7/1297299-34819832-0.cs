    private static DataTable GetPerformances(ObservableCollection<Performance> performances)
    {
        var dataTable = GetTableSkeleton(performances);
        var performanceGroups = performances
            .GroupBy(x => x.Location)
            .OrderBy(x => x.Key);
        foreach (var performanceGroup in performanceGroups)
        {
            var dataRow = dataTable.NewRow();
            dataRow["Location"] = $"Loc {performanceGroup.Key}";
            foreach (var performance in performanceGroup)
            {
                var columnName = GetColumnName(performance.StartTime);
                dataRow[columnName] = $"Perf {performance.Id}";
            }
            dataTable.Rows.Add(dataRow);
        }
        return dataTable;
    }
    
    private static DataTable GetTableSkeleton(IEnumerable<Performance> performances)
    {
        var timeRanges = performances
            .Select(x => x.StartTime)
            .Distinct()
            .OrderBy(x => x)
            .Select(x => new DataColumn(GetColumnName(x)))
            .ToArray();
        var dataTable = new DataTable();
        dataTable.Columns.Add("Location");
        dataTable.Columns.AddRange(timeRanges);
        return dataTable;
    }
    
    private static string GetColumnName(int startTime)
    {
        return $"{startTime}-{startTime + 1}";
    }
