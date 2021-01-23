    List<FrigoriferoClass> rawSource = new List<FrigoriferoClass>();
    rawSource.Add(new FrigoriferoClass(1,"1",1,2));
    rawSource[0].controllo.Add(new ControlloClass(12, new DateTime(2016, 8, 6)));
    rawSource[0].controllo.Add(new ControlloClass(13, new DateTime(2016, 8, 8)));
    rawSource.Add(new FrigoriferoClass(2,"2",1,2));
    rawSource[1].controllo.Add(new ControlloClass(3, new DateTime(2016, 8, 2)));
    rawSource[1].controllo.Add(new ControlloClass(5, new DateTime(2016, 8, 7)));
    DataTable itemSource = new DataTable("Table");
    itemSource.Columns.AddRange(rawSource.Select(x => new DataColumn(x.codice.ToString(CultureInfo.InvariantCulture))).ToArray());
    for (int i = 0; i < 31; i++) {
        var row = itemSource.NewRow();
        foreach (var item in from x in rawSource
                             from y in x.controllo
                             where y.data.Day == i
                                 select new {col = x.codice, val = y.temp})
            row[item.col.ToString(CultureInfo.InvariantCulture)] = item.val;
        itemSource.Rows.Add(row);
    }
