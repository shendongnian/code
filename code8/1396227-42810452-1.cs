    private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnString"].ConnectionString;
    MySqlConnection Conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DBConnString"].ConnectionString);
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Binddropdown();
        }
    }
    protected void Binddropdown()
    {
        Conn.Open();
        MySqlCommand cmd = new MySqlCommand("select * from Countries", Conn);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Conn.Close();
        ddlTip.DataSource = ds;
        ddlTip.DataTextField = "Name";
        ddlTip.DataValueField = "Id";
        ddlTip.DataBind();
        ddlTip.Items.Insert(0, new ListItem("--select--", "0"));
        ddlTip1.Items.Insert(0, new ListItem("--select--", "0"));
        ddlTip2.Items.Insert(0, new ListItem("--select--", "0"));
    }
    protected void ddlTip_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ddlTipId = Convert.ToInt32(ddlTip.SelectedValue);
        Conn.Open();
        MySqlCommand cmd = new MySqlCommand("select * from State where Country_Id=" + ddlTipId, Conn);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Conn.Close();
        ddlTip1.DataSource = ds;
        ddlTip1.DataTextField = "Name";
        ddlTip1.DataValueField = "Id";
        ddlTip1.DataBind();
        ddlTip1.Items.Insert(0, new ListItem("--select--", "0"));
        if (ddlTip1.SelectedValue == "0")
        {
           ddlTip2.Items.Clear();
           ddlTip2.Items.Insert(0, new ListItem("--select--", "0"));
        }
    }
    protected void ddlTip1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ddlTip1Id = Convert.ToInt32(ddlTip.SelectedValue);
        Conn.Open();
        MySqlCommand cmd = new MySqlCommand("select * from Region where State_Id=" + ddlTip1Id, Conn);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Conn.Close();
        ddlTip2.DataSource = ds;
        ddlTip2.DataTextField = "Name";
        ddlTip2.DataValueField = "Id";
        ddlTip2.DataBind();
        ddlTip2.Items.Insert(0, new ListItem("--select--", "0"));
    }
}
