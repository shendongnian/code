    var dt = new DataTable();
    dt.Columns.Add("A");
    dt.Rows.Add("GOOD");
    dt.Rows.Add("NOT GOOD");
    dt.Rows.Add("GOOD");
    dt.Rows.Add("PERFECT");
    dt.Rows.Add("PERFECT");
    dt.Rows.Add("GOOD");
    var result = dt.AsEnumerable()
                   .GroupBy(r => r.Field<string>("A"))
                   .Select(r => new
                                {
                                   Str = r.Key,
                                   Count = r.Count()
                                });
    foreach (var item in result)
    {
        Console.WriteLine($"{item.Str} : {item.Count}");
    }
    //GOOD : 3
    //NOT GOOD : 1
    //PERFECT : 2
