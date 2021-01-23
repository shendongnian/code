    protected void Page_Load(object sender, EventArgs e)
    {
       GridView grd = grdTest; //grdTest is Id of gridview
       BindGrid(grd);
                
    }
    public static void BindGrid(GridView grd)
    {
      using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("select* from testtable", con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        grd.DataSource = dt;
        grd.DataBind();
      }
    }
