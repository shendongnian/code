    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if(!IsPostBack)
        {
            // Variable
            string[] name = { "google", "yahoo" };
            string[] url = { "http://www.google.com", "http://www.yahoo.com" };
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Url");
            // Add to DataTable
            for (int i = 0; i < name.Length; i++)
                dt.Rows.Add(name[i], url[i]);
            // Check
            if (dt != null && dt.Rows.Count > 0)
            {
                rp.DataSource = dt;
                rp.DataBind();
            }
        }
    }
