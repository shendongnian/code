    public String[] ProductNames
    {
        get
        {
            return _productNames;
        }
        set
        {
            if (_productNames!= value)
            {
                _productNames = value;
                RaisePropertyChangedEvent("ProductNames");
            }
        }
    }
    String[] _productNames;
    public NameOfConstructor()
    {
        List<String> productNames = new List<String>();
        productNames.Add("A");
        productNames.Add("B");
        productNames.Add("C");
    
        ProductNames = productNames.ToArray();
    }
