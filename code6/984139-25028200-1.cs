    public class Person : IPersonBuilder
    {
      private string _name;
      private int? _age;
      private Person() { }
      public static IPersonBuilder WithName(string name)
      {
        return ((IPersonBuilder)new Person()).WithName(name);
      }
      public static IPersonBuilder WithAge(int age)
      {
        return ((IPersonBuilder)new Person()).WithAge(age);
      }
      IPersonBuilder IPersonBuilder.WithName(string name)
      {
        _name = name;
        return this;
      }
      IPersonBuilder IPersonBuilder.WithAge(int age)
      {
        _age = age;
        return this;
      }
      public void Save()
      {
        // do save
      }
    }
    public interface IPersonBuilder
    {
      IPersonBuilder WithName(string name);
      IPersonBuilder WithAge(int age);
      void Save();
    }
