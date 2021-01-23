    public abstract class Animal
    {
        public Animal(string name)
        {
            Name = name;
        }
    
        public readonly string Name;
    
        public abstract double Value { get; }
    }
    
    public class Dog : Animal
    {
        public Dog(string name, double weight)
            : base(name)
        {
            Weight = weight;
        }
    
        public readonly double Weight;
    
        public override double Value { get { return Weight; } }
    }
    
    public class Cat : Animal
    {
        public Cat(string name, bool old)
            : base(name)
        {
            Old = old;
        }
    
        public readonly bool Old;
    
        public override double Value { get { return Old ? 0 : 100; } }
    }
