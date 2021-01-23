    // create the data source
    DataTable tbl = new DataTable();
    tbl.Columns.Add("ItemID");
    tbl.Columns.Add("ItemCode");
    tbl.Columns.Add("UOM");
    tbl.Columns.Add("ItemName");
    tbl.Columns.Add("ReturnedQuantity");
    // populate the data source
    foreach (GridViewRow row in griddelpur.Rows)
    {
        // all your other logic, then...
        DataRow dr = tbl.NewRow();
        dr["ItemID"] = ItemID;
        dr["ItemCode"] = itemcode;
        dr["UOM"] = UOM;
        dr["ItemName"] = itemname;
        dr["ReturnedQuantity"] = Convert.ToInt32(OrderedQuantity) - Convert.ToInt32(ReceivedQuantity);
        tbl.Rows.Add(dr);
    }
    // use the data source
    gridpurahsereturn.DataSource = tbl;
    gridpurahsereturn.DataBind();
