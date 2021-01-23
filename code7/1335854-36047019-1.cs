    sqlRead = sqlCmd.ExecuteReader();
    var dt = new DataTable();
    for (var i = 0; i < sqlRead.FieldCount; i++)
    {
        dt.Columns.Add(sqlRead.GetName(i), typeof(string));
    }
    
    while (sqlRead.Read())
    {
        var row = dt.Rows.Add();
        for (var i = 0; sqlRead.FieldCount; i++)
        {
            var val = sqlRead[i].ToString();
            row[i] = val;
        }
    }
    sqlRead.Close();
