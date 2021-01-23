    // fields
    Product _product;
    // properties
    public virtual int ProductFk { get; set; }
    public virtual Product Product
    {
        get { return _product; }
        set
        {
            _product = value;
            ProductFk = _product != null ? _product.ProductId : 0;
        }
    }
