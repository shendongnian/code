    protected void Button1_Click(object sender, EventArgs e)
    {
        // I don't use this anymore :
        //            GridView1.DataSourceID = null;
        //            GridView1.DataSource = ds;
        ...
        // now I do this :
        // New query string to narrow down the selection based on the input
        string sSQL = "select ...";
        SqlDataSource1.SelectCommand = sSQL;
        ViewState.Add("MySQL", sSQL);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        LblResult.Text = "";
        if (!Page.IsPostBack)
        {
            GridView1.DataBind();
        }
        if (ViewState["MySQL"] != null)
        {
            SqlDataSource1.SelectCommand = (string)ViewState["MySQL"];
        }
    }
