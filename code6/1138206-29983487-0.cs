    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadData();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Write data to database
        LoadData();
    }
    private void LoadData()
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            //Here goes your sql code that reads the database
        }
    }
