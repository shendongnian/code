    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
    
    DataRow r = dt.NewRow();
    r[0] = "A00";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "B50";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "B99";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "c00";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "c30";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "c49";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "c50";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "d59";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "d50";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "d60";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "d89";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "E00";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "E50";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "E89";
    dt.Rows.Add(r);
    
    r = dt.NewRow();
    r[0] = "E90";
    dt.Rows.Add(r);
    
    var range1 = dt.AsEnumerable().Where (d => d[0].ToString().CompareTo("A") >= 0 && d[0].ToString().CompareTo("B99") <= 0);
    DataTable TableRange1 = range1.CopyToDataTable();
    
    var range2 = dt.AsEnumerable().Where (d => d[0].ToString().CompareTo("c00") >= 0 && d[0].ToString().CompareTo("d49") <= 0);
    DataTable TableRange2 = range2.CopyToDataTable();
    
    var range3 = dt.AsEnumerable().Where (d => d[0].ToString().CompareTo("E00") >= 0 && d[0].ToString().CompareTo("E89") <= 0);
    DataTable TableRange3 = range3.CopyToDataTable();
