    protected void Page_Load(object sender, EventArgs e)
    {
        int id=0;
        if(Request.QueryString["id"] !=null)
        {
         id=int.parse(Request.QueryString["id"].toSting());
        }
        if (!IsPostBack)
            {
                SqlDataSource SqlDataSource1 = new SqlDataSource();
                SqlDataSource1.ID = "SqlDataSource1";
                this.Page.Controls.Add(SqlDataSource1);
                SqlDataSource1.ConnectionString =                  System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                SqlDataSource1.SelectCommand = "SELECT * from table where id="+id;
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
            }
        }
