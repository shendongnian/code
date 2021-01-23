    class Program
    {
        public virtual void CalculateArea(int a, int b)
        {
            Console.WriteLine(a * b);
        }
    }
    class progrmm1 : Program
    {
        public override void CalculateArea(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        static void Main(string[] args)
        {
            Program obj = new progrmm1();
            Program obj1 = new Program();
    
            obj.CalculateArea(4, 5);
            obj1.CalculateArea(4, 5);
            Console.ReadLine();
        }
    }
