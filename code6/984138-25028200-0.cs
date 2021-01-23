    public class Person
    {
      public static IPersonBuilder WithName(string name)
      {
        return new PersonBuilder().WithName(name);
      }
      public static IPersonBuilder WithAge(int age)
      {
        return new PersonBuilder().WithAge(age);
      }
      private  class PersonBuilder : IPersonBuilder
      {
        private string _name;
        private int? _age;
        public IPersonBuilder WithName(string name)
        {
          _name = name;
          return this;
        }
        public IPersonBuilder WithAge(int age)
        {
          _age = age;
          return this;
        }
        public void Save()
        {
          // do save
        }
      }
    }
    public interface IPersonBuilder
    {
      IPersonBuilder WithName(string name);
      IPersonBuilder WithAge(int age);
      void Save();
    }
