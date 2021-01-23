    public class A
    {
        private Inputs _test;
    
        public A()
        {
            _test = new Inputs();
            new B(_test);
        }
    }
    
    
    public class B
    {
        private Inputs _input;
    
        public B(Inputs input)
        {
            _input= input;
        }
    }
