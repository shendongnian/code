    class sum
    {
        private int add (int a, int b) 
        {
            return a+b;
        }
    
        public Func<int, int, int> MyProperty
        {
            get { return add; }
        }
    }
