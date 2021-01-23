    class Test2 : ITest2
    {
        private int myProperty;
        public int MyProperty_Get()
        {
             return myProperty;
        }
        //Not in the interface..
        public void MyProperty_Set(int value)  
        {
             myProperty = value;
        }
    }
