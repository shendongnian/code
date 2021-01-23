    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Variable
            DataTable dt = new DataTable();
            dt.Columns.Add("MemberContactID");
            for (int i = 1; i <= 10; i++)
                dt.Rows.Add(i + "");
            ViewState["Data"] = dt;
            
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
            dt.Dispose();
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = ViewState["Data"] as DataTable;
    }
    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        // Check
        if (e.CommandName == "EditButton")
        {
            GridDataItem item = e.Item as GridDataItem;
            // Response the DataKeyValues
            Response.Write(item.GetDataKeyValue("MemberContactID"));
        }
    }
