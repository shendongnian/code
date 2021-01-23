    public Customer LoadById(int customerId)
    {
        using (var context = new MyDbContext()) 
        {
            var myCustomer = context.Customers.Find(customerId);
            if (myCustomer != null)
            {
                // Filter orders.
                context.Entry(myCustomer)
                    .Collection(c => c.Orders)
                    .Query() 
                    .Where(o => !o.IsDeleted)
                    .Load();
            }
            return myCustomer;
        }
    }
