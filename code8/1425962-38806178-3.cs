    List<DateTime> firstColumnDates = new List<DateTime>(Enumerable.Range(1, 31).Select(x => new DateTime(2016, 8, x)));
    List<FrigoriferoClass> rawSource = new List<FrigoriferoClass>();
    rawSource.Add(new FrigoriferoClass(1,"1",1,2));
    rawSource[0].controllo.Add(new ControlloClass(12, new DateTime(2016, 8, 6)));
    rawSource[0].controllo.Add(new ControlloClass(13, new DateTime(2016, 8, 8)));
    rawSource.Add(new FrigoriferoClass(2,"2",1,2));
    rawSource[1].controllo.Add(new ControlloClass(3, new DateTime(2016, 8, 2)));
    rawSource[1].controllo.Add(new ControlloClass(5, new DateTime(2016, 8, 7)));
    DataTable itemSource = new DataTable("Table");
    itemSource.Columns.Add(new DataColumn("Days", typeof(string)));
    itemSource.Columns.AddRange(rawSource.Select(x => new DataColumn(x.codice.ToString(CultureInfo.InvariantCulture))).ToArray());
    foreach (DateTime date in firstColumnDates) {
        var row = itemSource.NewRow();
        foreach (var item in from x in rawSource
                             from y in x.controllo
                             where y.data == date
                                 select new {col = x.codice.ToString(CultureInfo.InvariantCulture), val = y.temp})
            row[item.col] = item.val;
        row["Days"] = date.ToShortDateString();
        itemSource.Rows.Add(row);
    }
    List<List<string>> items = new List<List<string>>();
    List<DateTime> firstColumnDates = new List<DateTime>(Enumerable.Range(1, 31).Select(x => new DateTime(2016, 8, x)));
    for (int j = 0; j < firstColumnDates.Count; j++) {
        items.Add(new List<string>());
    }
    List<FrigoriferoClass> rawSource = new List<FrigoriferoClass>();
    rawSource.Add(new FrigoriferoClass(1,"1",1,2));
    rawSource[0].controllo.Add(new ControlloClass(12, new DateTime(2016, 8, 6)));
    rawSource[0].controllo.Add(new ControlloClass(13, new DateTime(2016, 8, 8)));
    rawSource.Add(new FrigoriferoClass(2,"2",1,2));
    rawSource[1].controllo.Add(new ControlloClass(3, new DateTime(2016, 8, 2)));
    rawSource[1].controllo.Add(new ControlloClass(5, new DateTime(2016, 8, 7)));
    Dictionary<int, int> mapping = new Dictionary<int, int>();
    for (int j = 0; j < rawSource.Count; j++) {
        mapping[rawSource[j].codice] = j;
    }
    int i = 0;
    foreach (DateTime date in firstColumnDates) {
        for (int j = 0; j < rawSource.Count + 1; j++) {
            items[i].Add(string.Empty);
        }
        items[i][0] = date.ToShortDateString();
        foreach (var item in from x in rawSource
                             from y in x.controllo
                             where y.data == date
                             select new {col = x.codice, val = y.temp.ToString(CultureInfo.InvariantCulture)}) {
            items[i][mapping[item.col] + 1] = item.val;
        }
        i++;
    }
    myGrid.ItemsSource = new ObservableCollection<FrigoriferoClassColumn>(items.Select(x => new FrigoriferoClassColumn(x)));
