    private string _sortDirection = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Varaible
            DataTable dt = new DataTable();
            String[] array = { "xyz", "foo", "bar" };
            dt.Columns.Add("Foo");
            // Loop
            for (int i = 0; i < array.Length; i++)
                dt.Rows.Add(array[i]);
            // Check & Bind
            if (dt != null)
            {
                // ViewState
                ViewState["Data"] = dt;
                gv.DataSource = dt;
                gv.DataBind();
                // Dispose
                dt.Dispose();
            }
        }
    }
    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Check
        _sortDirection = ViewState["SortFoo"] != null ? ViewState["SortFoo"] + "" : "";
        
        SetSortDirection(_sortDirection);
        ViewState["SortFoo"] = _sortDirection;
        
        DataTable dt = ViewState["Data"] as DataTable;
        dt.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
        gv.DataSource = dt;
        gv.DataBind();
        
    }
    private void SetSortDirection(string sortDirection)
    {
        
        if (sortDirection == "") _sortDirection = "ASC";
        else if (sortDirection == "ASC") _sortDirection = "DESC";
        else _sortDirection = "ASC";
    }
