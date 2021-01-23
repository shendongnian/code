    public item(int productNo)
    {
        InitializeComponent();
    
        var selectedProduct = product.FillProduct[productNo];
    
        sProduct = (selectedProduct.Name);
        this.Text = sProduct;
    
        sPrice = selectedProduct.Price;
        lblPrice.Text = "$" + sPrice;
    
        string Desc = selectedProduct.Description;
        lblDesc.Text = System.IO.File.ReadAllText(@Desc);
    
        string Img = selectedProduct.Image;
        picProduct.Image = Image.FromFile(Img);
    }
