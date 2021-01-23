    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            string[] productName = { "SharePoint", "CRM", "SiteCore", "Silver Light" };
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID");
            dt.Columns.Add("ProductName");
            for (int i = 0; i < productName.Length; i++)
                dt.Rows.Add((i + 1) + "", productName[i]);
            // Bind Grid View
            gv.DataSource = dt;
            gv.DataBind();
            // Bind Repeater
            r.DataSource = dt;
            r.DataBind();
        }
    }
    protected void r_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Variable
            string url = "/Products/Details?ProductID={0}";
            // Find Control
            HyperLink hl = e.Item.FindControl("hl") as HyperLink;
            Label lblHidden = e.Item.FindControl("lblHidden") as Label;
            // Check
            if (hl != null && lblHidden != null)
            {
                // Set Navigation Url
                url = string.Format(url, lblHidden.Text.Trim());
                hl.NavigateUrl = url;
            }
        }
    }
