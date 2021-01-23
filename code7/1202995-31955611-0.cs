    DataTable dt = new DataTable();
    dt = GetAccCode(c);
    DataView dv = new DataView(dt);
    dv.RowFilter = "AccountDescription LIKE %'" + e.Text + "'%" ;
    dv.RowFilter = "Isnull(AccountDescription,'') <> ''";
    
    dv.RowStateFilter = DataViewRowState.ModifiedCurrent;  
    if (dv.Count > 0)
    {
       dt = dv.ToTable(); 
    }
