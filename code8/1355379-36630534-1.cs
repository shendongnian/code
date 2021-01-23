    public abstract class Animal
    {
        public Animal() { }
        public virtual string Name => "Generic Animal";
        public abstract string Speak();
    }
    public class Dog : Animal
    {
        public override string Name => "Dog";
        public override string Speak() => "Bark";
    }
    public class Cat : Animal
    {
        public override string Name => "Cat";
        public override string Speak() => "Meow";
    }
