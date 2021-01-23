    public interface IPersonBuilder
    {
        IPersonBuilder WithName(string name);
        IPersonBuilder WithAge(int age);
        IPerson Save()
    }
    
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }
    }
    
    public class PersonBuilder
    {
        public PersonBuilder() { }
    }
    
    new PersonBuilder().WithAge(18).WithName("Steven").Save();
