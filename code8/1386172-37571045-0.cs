    if (!Page.IsPostBack)
    {
        try
        {
            gdview.DataSource = SqlDataSource1;
            gdview.DataBind();
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            DataTable dt = new DataTable();
            dt = dv.ToTable();
            ViewState["dt"] = dt;
        }
        catch(Exception ex)
        {
        }
    }
