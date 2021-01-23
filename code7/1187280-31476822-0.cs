    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
        
            SqlCommand com = new SqlCommand("SELECT DISTINCT Townland FROM Houses ORDER BY Townland ASC", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lstTown.DataTextField = ds.Tables[0].Columns["Townland"].ToString();
            lstTown.DataValueField = ds.Tables[0].Columns["Townland"].ToString();
            lstTown.DataSource = ds.Tables[0];
            lstTown.DataBind();
            lstTown.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            lstTown.SelectedIndex = 0;
        }
    }
