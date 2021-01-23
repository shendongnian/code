    class Test
    {
        public int Foo { get; set; }
        
        static void Main()
        {
            dynamic example = new Test();
            
            example.Foo = 10; // Fine
    
            object o = 10;
            example.Foo = o; // Bang
        }
    }
