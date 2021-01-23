    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            DataTable dt = new DataTable();
            dt.Columns.Add("T");
            // Loop & Add
            for (int i = 0; i < 10; i++)
                dt.Rows.Add(i + "");
            // Check & Bind
            if (dt != null)
            {
                ViewState["Grid"] = dt;
                RadGrid1.DataSource = dt;
                RadGrid1.DataBind();
                // Dispose
                dt.Dispose();
            }
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = ViewState["Grid"] as DataTable;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Write("GG");
    }
    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        // Check
        if (e.CommandName == "Search")
        {
            // Variable
            GridEditableItem item = e.Item as GridEditableItem;
            string something = "";
            // Find Control
            RadComboBox rcb = item.FindControl("rcb") as RadComboBox;
            // Check
            if (rcb != null)
            {
                // Set
                something = rcb.Text;
                // Do Something 
                Response.Write(something);
            }
        }
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        // Check
        if (e.Item is GridEditableItem)
        {
            // FindControl
            RadComboBox rcb = e.Item.FindControl("rcb") as RadComboBox;
            // Check
            if (rcb != null)
            {
                rcb.DataSource = ViewState["Grid"] as DataTable;
                rcb.DataTextField = "T";
                rcb.DataValueField = "T";
                rcb.DataBind();
            }
        }
    }
