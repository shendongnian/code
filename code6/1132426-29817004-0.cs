    public class Foo
    {
        private string Bar { get; set; }
        public string FooBar { get; set; }
    
        public Foo (string bar)
        {
            Bar = bar + "foo";
        }
    }
