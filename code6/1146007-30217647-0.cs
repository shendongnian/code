    public abstract class Animal
    {
        public string Name { get; private set; }
        public Animal(string name)
        {
            Name = name;
        }
    }
    public class Dog : Animal
    {
        public Dog()
            : base("Rover")
        {
            
        }
        public Dog(string name)
            : base(name)
        {
        }
    }
