    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class Foo 
    {
        public Foo()
        {
            Console.WriteLine("created foo");
        }
        ~Foo()
        {
            Console.WriteLine("Dead");
        }            
    }
