    private void SaveCustomer(TestModel ctx, Customer customer)
    {
        //save back
        ctx.Customers.Add(customer); // no more error!
        ctx.Entry(customer).State = EntityState.Modified;
        ctx.SaveChanges();
    }
