    private void LoadTables()
    {
        // Mock the tables data
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        // Clear data from gridview
        GridView1.DataSource = null;
        GridView1.DataBind();
        // Load first table
        GridView1.DataSource = dt1;
        GridView1.DataBind();
        // Clear data from gridview
        GridView1.DataSource = null;
        GridView1.DataBind();
        // Load second table
        GridView1.DataSource = dt2;
        GridView1.DataBind();
    }
