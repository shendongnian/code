    public void SetSelectedCustomer(int customerId)
    {
        var customer = _repository.GetCustomerById(customerId);
        FirstName = customer.FirstName;
        LastName = customer.LastName;
        Address = customer.Address;
    }
