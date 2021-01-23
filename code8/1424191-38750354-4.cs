    class B
    {
        public Prop {get; set;}
    }
    static void Main(string[] args)
        { 
            Console.WriteLine(GetName<B>((b) => b.Prop));
            //Or
            var someObject = new B();
            Console.WriteLine(GetName(() => someObject.Prop) );
            Console.ReadLine();
        }
