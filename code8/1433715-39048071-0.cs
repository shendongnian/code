    public void UpdateCustomer(Customer customer)
    {
        var customerTopdate=dbContext.Customers.Where(c=>c.Id=customer.Id);
        var result=AutoMapper.Map<Customer>(customer,customerTopdate);
        dbContext.SaveChanges();
    }
