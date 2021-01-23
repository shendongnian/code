    public List<Consumer> GetAllCustomers() {
       return
          new NorthwindDataContext()
          .Output_Masters
          .Where(consumer => consumer.SomeParameter == someValue)
          .ToList();
    }
