    public interface IAnimal
    {
        IAnimal GetAnimal();
    }
    public class Dog : IAnimal
    {
        IAnimal GetAnimal() { return new Dog(); }
    }
