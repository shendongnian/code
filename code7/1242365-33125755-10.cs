    string[] lines = File.ReadAllLines(path);
    string[] columns = lines[0].Split(new[] { delimiter }, StringSplitOptions.None);
    string[] types   = lines[1].Split(new[] { delimiter }, StringSplitOptions.None);
    DataTable tblImport = new DataTable();
    for (int i = 0; i < columns.Length; i++)
    {
        string colName  = columns[i];
        string typeName = types[i];
        tblImport.Columns.Add(colName, Type.GetType(typeName));
    }
    // import data
    // use a typeValueConverter dictionary to convert values:
    var typeValueConverter = new Dictionary<Type, Func<string, object>> {
        { typeof(DateTime), value =>  value.TryGetDateTime(null, null) },
        { typeof(Decimal),  value =>  value.TryGetDecimal(null) },
        { typeof(int),      value =>  value.TryGetInt32(null) },
    };
    foreach (string line in lines.Skip(2))
    { 
        string[] fields = line.Split(new[]{ delimiter }, StringSplitOptions.None);
        DataRow r = tblImport.Rows.Add(); // already added at this point
        for(int i = 0; i < tblImport.Columns.Count; i++)
        {
            DataColumn col = tblImport.Columns[i];
            object val = fields[i];
            if(typeValueConverter.ContainsKey(col.DataType))
                val = typeValueConverter[col.DataType](fields[i]);
            r.SetField(col, val);
        }
    }
    System.Threading.Thread.CurrentThread.CurrentCulture = oldCulture;
