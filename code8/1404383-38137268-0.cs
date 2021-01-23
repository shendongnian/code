    var t = new DataTable();
    t.Columns.Add(new DataColumn("Value", typeof(decimal)));
    t.Rows.Add(.5m);
    t.Rows.Add(.5m);
    t.Rows.Add(.5m);
    t.Rows.Add(0m );
    t.Rows.Add(0m );
    t.Rows.Add(0m );
    
    t.Compute("COUNT(Value)", "Value > 0").Dump();
    t.Compute("SUM(Value)", "Value > 0").Dump();
