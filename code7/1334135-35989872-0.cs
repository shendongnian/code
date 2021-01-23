    public void SaveCustomer(customer_table customer)
    {
        if (customer.customerID == 0)
        {
            context.customer_table.Add(customer);
        }
        else
        {            
            context.customer_table.AddOrUpdate(customer);
        }
        context.SaveChanges();
    }
