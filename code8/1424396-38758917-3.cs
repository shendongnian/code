    var dt1 = new DataTable();
    dt1.Columns.Add("ID", typeof(int));
    dt1.Columns.Add("Name", typeof(string));
    dt1.Rows.Add(1, "Jon");
    var dt2 = new DataTable();
    dt2.Columns.Add("Country", typeof(string));
    dt2.Rows.Add("US");
    var dtMerged = MergeTablesByIndex(dt1, dt2);
