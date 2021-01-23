	protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
		gvObjects.DataSource = LoadCachedObjects();
		gvObjects.DataBind();
	}
	private DataTable LoadCachedObjects()
    {
        var result = new DataTable();
        if ((Session["CachedDataTable"] != null) && (IsPostBack))
        {
            //cached DataTable will only be used on PostBack
            result = Session["CachedDataTable"] as DataTable;
        }
        if (result.Rows.Count == 0)
        {
            result = LoadObjects(); //Get data from the database
            Session["CachedDataTable"] = result;
        }
        return result;
    }
