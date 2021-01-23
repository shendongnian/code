    public abstract class Animal {
        public abstract int Legs { get; }
        public virtual void Speak() { Console.WriteLine("..."); }
        public abstract void Accept(IAnimalVisitor visitor);
    }
