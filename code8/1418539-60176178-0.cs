    using (var dr = cmd.ExecuteReader())
    {
        var dt = new DataTable();
    
        using (var ds = new DataSet() { EnforceConstraints = false })
        {
            ds.Tables.Add(dt);
            dt.BeginLoadData();
            dt.Load(dr);
            dt.EndLoadData();
            ds.Tables.Remove(dt);
        }
    }
