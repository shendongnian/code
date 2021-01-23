    protected void Page_Load(object sender, EventArgs e)
    {
    if (Request.QueryString["update"] !=null)
    {
        if (!Page.IsPostBack)
        {
            bindcategories();
            bindachievments();
            bindbrands();
        
        int id = int.Parse(Request.QueryString["update"]);
        string query = "SELECT * FROM ProductView WHERE id = " + id.ToString();
        DataTable dtupd = new DataTable();
        dtupd = param.All_data(query);
        string name = "",available="",category="",brand="",achievement="",image="";
        decimal price=0;
        int unit = 0;
        foreach (DataRow row in dtupd.Rows)
        {
             name = row.Field<string>("product_name");
             price = row.Field<decimal>("price");
             unit = row.Field<int>("unit");
             image = row.Field<string>("product_image");
             available = row.Field<string>("available");
             category = row.Field<string>("category_name");
             brand = row.Field<string>("brand_name");
             achievement = row.Field<string>("achievement");
        }
        txt_name.Text = name;
        txt_price.Text = price.ToString();
        txt_unit.Text = unit.ToString();
        product_image.ImageUrl = "../" + image;
        dd_available.ClearSelection();
        dd_available.SelectedValue = available;
        dd_category.ClearSelection();
        dd_category.Items.FindByText(category).Selected = true;
        dd_brand.ClearSelection();
        dd_brand.Items.FindByText(brand).Selected = true;
        dd_achievment.ClearSelection();
        dd_achievment.Items.FindByText(achievement).Selected = true;
        btn_Insert.Text = "Update Product";
        }
    }
    else
    {
        if (!Page.IsPostBack)
        {
            bindcategories();
            bindbrands();
            bindachievments();
        }
        if (!FileUpload1.HasFile)
        {
            product_image.ImageUrl = "../assets/images/products/default.png";
        }
    }
    }
