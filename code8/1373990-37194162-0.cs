    public class FooBar
    {
        public int Number { get; }
    
        public FooBar()
        {
            Number = 10;
        }
    
        public FooBar(int number) : this()
        {
            Number = number;
        }
    }
    var fooBar1 = new FooBar();   // fooBar1.Number == 10
    var fooBar2 = new FooBar(20); // fooBar2.Number == 20
