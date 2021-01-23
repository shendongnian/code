    private object _SelectedProduct;
    public object SelectedProduct
    {
        get { return _SelectedProduct; }
        set
        {
            _SelectedProduct = value;
            
            //Call a method in your view model here.
            DoSomethingUseful();
        }
    }
