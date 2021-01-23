    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string productID;
        DataServiceContext svcContext = 
            new DataServiceContext(new Uri("AdventureWorks.svc", UriKind.Relative));
    
        if (this.NavigationContext.QueryString.ContainsKey("ProductId"))
        {
            productID = this.NavigationContext.QueryString["ProductId"];
        }
        else
        {
            productID = App.Current.Resources["FeaturedProductID"].ToString();
        }
    
        svcContext.BeginExecute<Product>(new Uri("Product(" + productID + ")", 
            UriKind.Relative), loadProductCallback, svcContext);
    
    }
