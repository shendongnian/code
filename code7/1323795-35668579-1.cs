        using (TestModel ctx = new TestModel())
        {
            var customer = GetCustomer(ctx);
            //set new name
            customer.Name = "New Name";
            ctx.SaveChanges();
        }
