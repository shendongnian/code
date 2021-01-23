    private IEnumerable<ProductCategory> productCategoryList;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
             productCategoryList = ProductService.GetProductCategories();
        }
    }
