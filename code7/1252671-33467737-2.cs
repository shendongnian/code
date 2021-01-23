    var bindableDt = new Datatable();
    bindableDt.Columns.Add("colName1")
    bindableDt.Columns.Add("colName2")
    
    foreach(var item in dt.Rows)
    {
        bindableDt.Row.Add(dt.Rows[0], dt.Rows[1]);
    }
    gridview.Datasource = bindableDt;
    
