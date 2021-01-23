    var query = dtTest.AsEnumerable();
    
    if (dropdown1.SelectedIndex > 0)
        query = query.Where(r => r.Field<string>("Name") == ViewState["EN"].ToString());
    
    if (dropdown2.SelectedIndex > 0)
        query = query.Where(r => r.Field<string>("Super") == ViewState["SU"].ToString());
    
    // etc
    
    DataTable selectedTable = query.CopyToDataTable();
