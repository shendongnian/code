    public interface IPerson
    {
    }
    public class Person : IPerson
    {
    }
    public interface IEmployee : IPerson
    {
    }
    public class Employee : Person, IEmployee
    {
    }
