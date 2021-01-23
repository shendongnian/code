    class B
    {
        public Prop {get; set;}
    }
    static void Main(string[] args)
        { 
            PrintName<B>((b) => b.Prop); 
            //Or
            var someObject = new B();
            PrintName(() => someObject.Prop); 
            Console.ReadLine();
        }
