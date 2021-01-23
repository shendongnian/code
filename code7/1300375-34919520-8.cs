    public class FooViewModel
    {
      public string From { get;set; }
      public string To { get;set; }
      // represents the selected value
      public string CusName { get;set; }
      public List<Customer> AvailableCustomers { get;set;}
    }
    public class Customer 
    {
      public int Id { get;set;}
      public string Name { get;set;}
    }
