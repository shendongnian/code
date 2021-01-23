    protected void Page_Load(object sender, EventArgs e)
        {
            ShopifyAuthorizationState state = HttpContext.Current.Session["Shopify.AuthState"] as ShopifyAuthorizationState;
            ShopifyAPIClient client
                = new ShopifyAPIClient(state);
            var myJsonString = (string)client.Get("/admin/products.json");
            var table = JsonConvert.DeserializeObject<datatable>(myJsonString );
            gvproducts.DataSource = table ;
        	gvproducts.DataBind();
        } 
