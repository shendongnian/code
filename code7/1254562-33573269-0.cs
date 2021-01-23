    ds = new DataSet("PayCharge"); 
    ds= obj.GetData(); 
    DataColumn dc = new DataColumn("Select", typeof(boolean));
    dc.DefaultValue = false;
    ds.Tables[0].Columns.Add(dc);
    grdVisPay.SetDataBinding(ds, "PayCharge");  
    .....
