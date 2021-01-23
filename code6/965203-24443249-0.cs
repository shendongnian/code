        DataTable table = new DataTable();
        table.Columns.Add("Label", typeof(string));
        table.Columns.Add("Number", typeof(int));
        table.Rows.Add(new object[] { "Apple", 1 });
        table.Rows.Add(new object[] { "Apple", 2 });
        table.Rows.Add(new object[] { "Orange", 5 });
        table.Rows.Add(new object[] { "Orange", 10 });
        var CombinedView = from rowGroup in table.Rows.OfType<DataRow>().GroupBy(r => r.Field<string>("Label"))
                           select new { Label = rowGroup.Key, Number = rowGroup.Sum(r => r.Field<int>("Number")) };
