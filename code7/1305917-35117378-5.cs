    public string ProductName
    {
        get
        {
            if (this.Product != null)
                return this.Product.Name;
            else 
                return string.Empty;
        }
    }
