    public interface IName
    {
      string Name { get; set; }
    }
    public class Person : IName
    {
      public string Name { get; set; }
    }
    public class Dog : IName
    {
      public string Name { get; set; }
    }
