    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateOrderList();
    }
    private void PopulateOrderList()
    {
        DateTime d;
        DateTime d2;
        DataTable dts = new DataTable();
        dts.Columns.Add("OrderDate", typeof(string));
        dts.Columns.Add("OrderNumber", typeof(string));
        dts.Columns.Add("OrderItemSKUName", typeof(string));
        dts.Columns.Add("SKUNumber", typeof(string));
        dts.Columns.Add("OrderItemStatus", typeof(string));
        dts.Columns.Add("OrderItemUnitCount", typeof(string));
        dts.Columns.Add("mtrx_Code2", typeof(string));
            DataRow drNew = dts.NewRow();
            drNew["OrderDate"] = DateTime.Now.ToShortDateString();
            drNew["OrderNumber"] = "122";
            drNew["OrderItemSKUName"] = "sku";
            drNew["SKUNumber"] = "skunum";
            drNew["OrderItemStatus"] = "Done";
            drNew["OrderItemUnitCount"] = "1290";
            drNew["mtrx_Code2"] ="abc123";
            dts.Rows.Add(drNew);
        
        Session["Data"] = dts;
        gridview.Visible = true;
        gridview.DataSource = dts.DefaultView;
        gridview.DataBind();
       
    }
    protected void gridview_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        DataTable dt = (DataTable)Session["Data"];
    }
