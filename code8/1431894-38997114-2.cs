    abstract class AbstractClass
    {
        protected string Details { get; set; }
        public DateTime DT { get; set; }
        private AbstractClass() { }
        protected AbstractClass(string details) { Details = details;}
        public virtual void Print()
        {
            Console.WriteLine($"{Details} {DT}");
        }
    }
    internal class ClassA : AbstractClass
    {
        public ClassA() : base("A") { }
    }
    class ClassB : AbstractClass
    {
        public ClassB() : base("B") { }
    }
