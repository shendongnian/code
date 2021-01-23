    protected void Page_Load(object sender, EventArgs e)
        {
            List<Product> prods = session.Query<Product>().ToList();
            if(!IsPostBack)
            {
                repProducts.DataSource = prods;
                repProducts.DataBind();
            }
        }
