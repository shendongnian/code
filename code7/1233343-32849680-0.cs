    interface ICloneable<T>
    {
      T Clone();
    }
    [Alias("Boo")]
    public class Foo : ICloneable<Foo>
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public Foo Clone() { ... }
    }
