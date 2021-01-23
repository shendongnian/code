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
            dt.Column.Add("RowNo");
            // Loop
            for (int i = 0; i < array.Length; i++)
                dt.Rows.Add(array[i], (i + 1).ToString());
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
        // Define New DataTable
        DataTable dt1 = new DataTable();
        dt1.Column.Add("Foo");
        dt1.Column.Add("RowNo");
        // Loop
        for (int i = 0; i < dt.Rows.Count; i++) 
             dt1.Rows.Add(dt.Rows[i]["Foo"] + "", (i + 1).ToString()); 
        
        // Save to ViewState
        ViewState["SortFoo"] = dt1;        
        // Bind
        gv.DataSource = dt1;
        gv.DataBind();
        
    }
    private void SetSortDirection(string sortDirection)
    {
        
        if (sortDirection == "") _sortDirection = "ASC";
        else if (sortDirection == "ASC") _sortDirection = "DESC";
        else _sortDirection = "ASC";
    }
