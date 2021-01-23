    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource =  AmbilJadwal(nomorSt);
            GridView1.DataBind();
        }
    }
