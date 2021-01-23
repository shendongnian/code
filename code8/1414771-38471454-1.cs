    private int accessCount = 0;
    private Customers[] _customers;
    private Customers[] customers 
    {
        get
        {
            accessCount++;
            return _customers;
        }
        set
        {
            _customers = value;
        }
    }
