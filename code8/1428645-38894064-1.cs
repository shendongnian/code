    var colspecs = new ColSpec[] { 
        new ColSpec { Type = typeof(int), Name = "int" }, 
        new ColSpec { Type = typeof(string), Name = "string" } };
    var dt = new DataTable();
    dt.Columns.AddRange (colspecs.Select(x=> new DataColumn(x.Name, x.Type) ).ToArray()) ;
    // single row jagged array 
    object[][] myObj = new object[1][];
    // 2 colums per row
    myObj[0] = new object[2] {100, "string"};
    foreach (object[] objs in myObj)
        dt.Rows.Add(objs);
