    var dt = new DataTable();
    dt.Columns.Add("Foo", typeof(string));
    dt.Columns.Add("Bar", typeof(int));
    dt.Rows.Add("Test", 1);
    dt.Rows.Add("Test", 2);
    dt.Rows.Add("Testing",1);
    dt.Rows.Add("Testing",1);
    var dictionary = new Dictionary<DataRow, int>(DataRowComparer<DataRow>.Default);
    foreach(var row in dt.AsEnumerable())
    {
        if (!dictionary.ContainsKey(row)) dictionary[row] = 1;
        else dictionary[row]++;
    }
