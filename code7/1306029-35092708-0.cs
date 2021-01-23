    public interface IAnimal
    {
        void Eat();
    }
    public class Dog : IAnimal
    {
        void IAnimal.Eat() { }
    }
    IAnimal animal = new Dog();
    animal.Eat(); // <---- OK
    
    Dog animal2 = new Dog();
    animal2.Eat(); // <---- COMPILE ERROR
