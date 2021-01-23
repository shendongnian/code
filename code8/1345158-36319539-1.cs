    var subTotalByAccount = table.AsEnumerable()
                .GroupBy(g => g.Field<string>("Account"))
                .Select(g => new { Account = g.Key, SubTotal = g.Sum(p => p.Field<decimal>("Payment")) })
                .ToDictionary(t => t.Account, t => t.SubTotal);
    table.Columns.Add("SubTotal", typeof(decimal));
    foreach (var row in table.AsEnumerable())
    {
                row.SetField(columnName: "SubTotal", value: subTotalByAccount[row.Field<string>("Account")]);
    }
