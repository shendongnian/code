    public class FooBar
    {
        public int Number { get; }
        public string Name { get; }
    
        public FooBar()
        {
            Number = 10;
            Name = "Pickles";
        }
    
        public FooBar(int number) : this()
        {
            Number = number;
        }
        public FooBar(int number, string name) : this(number)
        {
            Name = name;
        }
    }
    var fooBar1 = new FooBar();   
    var fooBar2 = new FooBar(20);
    var fooBar3 = new FooBar(77, "Stackoverflow");
    // The following would be true
    // fooBar1.Number == 10 and fooBar1.Name == "Pickles"
    // fooBar2.Number == 20 and fooBar2.Name == "Pickles"
    // fooBar3.Number == 77 and fooBar2.Name == "Stackoverflow"
