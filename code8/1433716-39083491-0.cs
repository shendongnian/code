    public void UpdateCustomer(Customer customer)
    {
        var customerTopdate=dbContext.Customers.Where(c=>c.Id=customer.Id);
        
        if (customerTopdate != null {
           _mapper.Map(customer,customerTopdate);
           _context.SaveChanges();
        }
    }
