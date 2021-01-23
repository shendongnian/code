    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            gvEvents.DataSource = this.GetEvents();
            gvEvents.DataBind();
        }
    }
    private DataTable GetEvents()
    {
        var table = new DataTable();
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        using(var connection = new SqlConnection(connectionString))
        {
            using(var command = new SqlCommand("SELECT TOP 100 Date,Time,Event,Venue FROM Event",connection))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Close();
            }
        }
        int rows = table.Rows.Count;//Place breakpoint to make sure table has rows
        return table;
    }
    protected void gvEvents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEvents.PageIndex = e.NewPageIndex;
        gvEvents.DataSource = this.GetEvents();
        gvEvents.DataBind();
    }
