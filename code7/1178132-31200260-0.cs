    public class Service
    {
      public double Cost { get; set; }
      public ICollection<ChildService> ChildServices { get; set; }
    }
    public class ChildService
    {
      public double Fee { get; set; }
    }
