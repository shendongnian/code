    public CustomerController2()
    {
        this._repository = new CustomerRepository();
    }
    public CustomerController2(ICustomerRepository repository)
    {
        this._repository = repository;
    }
