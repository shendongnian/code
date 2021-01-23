        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                   gridview1.DataSource = <some data source>;
                   gridview1.DataBind();  
            }
        }
