    public IPageViewModel homeViewModel{get; set;}
    public IPageViewModel productsViewModel{get; set;}
    
    ...
    IPageViewModel homeViewModel = new HomeViewModel();
    IPageViewModel productsViewModel = new ProductsViewModel();
