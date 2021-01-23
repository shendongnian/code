    var dictShort = dsShort.Tables[0].AsEnumerable()
                .GroupBy(row=> row, DataRowComparer.Default)
                .Where(g => exp.GroupSizeOk((uint)g.Count()))
                .OrderBy(g => g.Count())
                .ToDictionary(g => g.Key.ToString(), g => g.ToList());
