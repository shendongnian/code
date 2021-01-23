    var dt = new DataTable();
    dt.Columns.Add("Key", typeof(string));
    dt.Columns.Add("Val1", typeof(int));
    dt.Columns.Add("Val2", typeof(int));
    dt.Columns.Add("Val3", typeof(int));
    
    dt.Rows.Add("Field1", 100, 200, 300);
    dt.Rows.Add("Field2", 75, 200, 300);
    dt.Rows.Add("Field3", 50, 200, 300);
    dt.Rows.Add("Field4", 25, 200, 300);
    
    var dt2 = dt.AsEnumerable().OrderBy(x => x.Field<int>("Val1"));
    foreach (DataRow dr in dt2)
    {
    	Console.WriteLine("{0}, {1}, {2}, {3}", dr["Key"], dr["Val1"], dr["Val2"], dr["Val3"]);
    }
