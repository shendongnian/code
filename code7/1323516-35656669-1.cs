    DataColumn newColumn = new System.Data.DataColumn("pvar", typeof(System.String));
    table.Columns.Add(newColumn);
    foreach (DataRow currentRow in table.Rows)
    {
        var pvar = table.AsEnumerable() 
            .Where (r => r["Column1"].Equals(currentRow["Column1"]))
            .Select (r => string.Format("{0}|{1}", r["Column2"], r["Column3"]))
            .Aggregate((s, t) => string.Format("{0}|{1}", s, t));
        currentRow["pvar"] = pvar;
    }
