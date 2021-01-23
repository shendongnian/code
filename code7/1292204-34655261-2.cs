    class B :A
    {
        public override void print()
        {
            Console.WriteLine("B called");
            Console.Read();
        }
        public virtual void printfromB()
        {
            Console.WriteLine("printfromB in B called");
            Console.Read();
        }
    }
    class C : B
    {
        public override void print()
        {
            Console.WriteLine("C called");
            Console.Read();
        }
        public override void printfromB()
        {
            Console.WriteLine("printfromB in C called");
            Console.Read();
        }
    }
