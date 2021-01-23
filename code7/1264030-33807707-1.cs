    if (!IsPostBack)
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "SqlDataSource1";
            this.Page.Controls.Add(SqlDataSource1);
            SqlDataSource1.InsertParameters.Add(new Parameter("luser"));
            SqlDataSource1.InsertParameters["luser"].DefaultValue = HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name : String.Empty;
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT top 3 UserId, Friending from Friendreq Where Friending = @luser";
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }
