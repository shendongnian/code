    class A
    {
        private init()
        {
           // do initializations here
        }
    
        public A()
        {
            init();
        }
        public void methodA()
        {
            // reinitialize the object
            init();
     
            // other stuff may come here
        }
    }
