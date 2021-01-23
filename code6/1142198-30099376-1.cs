    public abstract class Animal {
    
        public Animal(string name) {
            Name = name;
        }
    
        public readonly string Name;
    
        public abstract double Value();
    
    }
    
    public class Dog : Animal {
    
        public Dog(string name, double weight) : base(name) {
            Weight = weight;
        }
    
        public readonly double Weight;
    
        public override double Value() {
            return dog.Weight;
        }
    
    }
    
    public class Cat : Animal
    {
        public Cat(string name, bool old) : base(name) {
            Old = old;
        }
    
        public readonly bool Old;
    
        public override double Value() {
            if (Old) {
                return 100.0;
            } else {
                return 0.0;
            }
        }
    
    }
