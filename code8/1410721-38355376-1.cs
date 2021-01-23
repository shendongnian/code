    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter("Select * From UserInfo", con);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                con.Close();             
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
