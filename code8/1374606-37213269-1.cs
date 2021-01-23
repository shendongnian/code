    public class Cat : Animal {
        public bool IsMewling { get; set; }
        public override int Legs { get; } = 4;
        public override void Accept(IAnimalVisitor visitor) { visitor.Visit(this); }
        public override void Speak() { Console.WriteLine("Meow"); }
    }
    public class Dog : Animal {
        public bool IsBarking { get; set; }
        public override int Legs { get; } = 4;
        public override void Accept(IAnimalVisitor visitor) { visitor.Visit(this); }
        public override void Speak() { Console.WriteLine("Woof"); }
    }
