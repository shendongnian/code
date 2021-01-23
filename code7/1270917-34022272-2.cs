    abstract class Prototype<T> where T : Prototype<T> 
    {
        public T Clone()
        {
            return this.MemberwiseClone() as T;
        }
    }
    class ConcretePrototype1 : Prototype<ConcretePrototype1> 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class ConcretePrototype2 : Prototype<ConcretePrototype2> 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConcretePrototype1 inst1 = new ConcretePrototype1()
            {
                Id = 1,
                Name = "Jon Skeet"
            };
            ConcretePrototype2 inst2 = new ConcretePrototype2()
            {
                Id = 2,
                Name = "Frodo Torbins"
            };
            ConcretePrototype1 copy1 = inst1.Clone();
            ConcretePrototype2 copy2 = inst2.Clone();
            Console.WriteLine(copy1.Name + "  " + copy1.GetType().Name);
            Console.WriteLine(copy2.Name + "  " + copy2.GetType().Name);
        }
    } 
