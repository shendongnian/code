    public List<Consumer> GetAllCustomers() {
       using (var northwind = new NorthwindDataContext())
          return
             northwind
             .Output_Masters
             .Where(consumer => consumer.SomeParameter == someValue)
             .ToList();
    }
