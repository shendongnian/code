    public interface IName
    {
      public string Name { get; }
    }
    public class Car : IName
    {
      public string Name { get; set; }
      public string Manufacturer { get; set; }
    }
    public class Animal : IName
    {
      public string Name { get; set; }
      public string Species { get; set; }
    }
    public class Planet : IName
    {
      public string Name { get; set; }
      public string ContainSystem { get; set; }
    }
