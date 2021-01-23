    private void SaveCustomer(TestModel ctx, Customer customer)
    {
        //save back
        ctx.Customers.Attach(customer); //GET ERROR HERE
        ctx.Entry(customer).State = EntityState.Modified;
        ctx.SaveChanges();
    }
