    internal class FooBarParent
        {
            public virtual void Display()
            {
                Console.WriteLine("FooBarParent::Display");
            }
        }
    
        internal class FooBarSon : FooBarParent
        {
            public override void Display()
            {
                Console.WriteLine("FooBarSon::Display");
            }
        }
    
        internal class FooBarDaughter : FooBarParent
        {
            public override void Display()
            {
                Console.WriteLine("FooBarDaughter::Display");
            }
        }
