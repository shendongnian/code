    DataTable items = new DataTable();
    items.Columns.Add("number");
    items.Columns.Add("qty");
    var result = from r in items.AsEnumerable()
                 group r by r.Field<string>("number") into grp
                 select new {
                     number = grp.Key,
                     qty = grp.Sum(r => r.Field<int>("qty"))
                 };
    DataTable newItems = new DataTable();
    newItems.Columns.Add("number");
    newItems.Columns.Add("qty");
    foreach (var item in result) {
        DataRow newRow = newItems.NewRow();
        newRow["number"] = item.number;
        newRow["qty"] = item.qty;
        newItems.AddRow(newRow);
    }
