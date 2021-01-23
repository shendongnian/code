    public class Animal
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
        public void Talk()
        {
            Console.WriteLine("{0} is talking", Name);
        }
    }
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }
    }
    public class Dog : Animal
    {
        public string FurColor { get; set; }
        public Dog(string name, string furColor) : base(name)
        {
            FurColor = furColor;
        }
        public void Greeting()
        {
            Console.WriteLine("{0} has {1} fur.", Name, FurColor);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat("Rex");
            cat.Talk();
            var dog = new Dog("Beanie", "Red");
            dog.Talk();
        }
    }
