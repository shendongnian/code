    public Product()
    {
        this.PageToProduct = new HashSet<PageToProduct>();
        this.ProductRates = new HashSet<ProductRates>();
        this.ProductToRider = new HashSet<ProductToRider>();
        Initialize();
    }
    partial void Initialize();
