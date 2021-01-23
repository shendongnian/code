    public interface IPerson
    {
        // All the methods/properties that make a person
    }
    public abstract class Person : IPerson
    {
        // All the common implementations
    }
    public class Doctor/Student/Teacher/etc... : Person
    {
        // All the specific implementations
    }
