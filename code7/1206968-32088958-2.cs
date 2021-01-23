    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Varaible
            DataTable dt = new DataTable();
            dt.Columns.Add("A");
            dt.Columns.Add("B");
            for (int i = 0; i < 3; i++)  dt.Rows.Add(i.ToString(), i.ToString()); 
            // Bind
            gv.DataSource = dt;
            gv.DataBind();
        }
    }
