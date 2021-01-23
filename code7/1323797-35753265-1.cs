    private void SaveCustomer(TestModel ctx, Customer customer)
    {
        //save back
        ctx.Customers.Add(customer); // no more error!
        ctx.Entry(customer).State = EntityState.Modified;
        // Prevent countries from being added to database (they already exist in db)
        ctx.Entry(customer.Country).State = EntityState.Detatched;
        ctx.Entry(customer.Country1).State = EntityState.Detatched;
        ctx.SaveChanges();
    }
