    var dt = new DataTable();
    dt.Columns.Add("Foo", typeof(string));
    dt.Columns.Add("Bar", typeof(int));
    dt.Rows.Add("Test", 1);
    dt.Rows.Add("Test", 2);
    dt.Rows.Add("Testing",1);
    dt.Rows.Add("Testing",1);
    var hash = new HashSet<DataRow>(DataRowComparer<DataRow>.Default);
    foreach(var row in dt.AsEnumerable())
    {
        if (hash.Contains(row)) Console.WriteLine("Already in data set");
        hash.Add(row);
    }
