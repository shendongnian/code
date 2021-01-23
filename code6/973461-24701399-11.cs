    protected void Page_Load()
    {
        if(!IsPostback)
        {
             List<Product> products=new List<Product>();
             products.Add(new Product(){Name="Toothbrush", Description="Fights cavities", ProductId="tb1"});
             products.Add(new Product(){Name="Vacuum Cleaner", Description="super vac!", ProductId="vac"});
             products.Add(new Product(){Name="iPod", Description="Plays your music.", ProductId="ipod"});
             ProductsRepeater.DataSource=products;
             ProductsRepeater.DataBind();
        }
    }
    
    protected void AddToCartBtn_Click(object sender, EventArgs e)
    {
        Button button=sender as Button;
        string productid=button.CommandArgument;
        Response.Redirect(String.Format("startpage.aspx?ID={0}", productid));
    }
