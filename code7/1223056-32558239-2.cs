    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Varaible
            DataTable dt = new DataTable();
            dt.Columns.Add("Filter");
            dt.Columns.Add("Name");
            // Add
            dt.Rows.Add("Do", "Doraemon");
            dt.Rows.Add("No", "Nobita");
            dt.Rows.Add("Si", "Sizuka");
            dt.Rows.Add("Sin", "Sinyu");
            // Bind
            gv.DataSource = dt;
            gv.DataBind();
        }
    }
