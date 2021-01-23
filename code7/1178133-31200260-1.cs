    public class Service
    {
      public long Id { get; set; }
      public double Cost { get; set; }
      public ICollection<ChildService> ChildServices { get; set; }
    }
    public class ChildService
    {
      public long Id { get; set; }
      public double Fee { get; set; }
    }
