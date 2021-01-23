    public void Test1 : ITest
    {
        public int MyProperty { get; private set; }
        public void changeValue() 
        {
            this.MyProperty = 12;
        }
    }
    public void Test2 : ITest
    {
        public int MyProperty { get; set; }
        public void changeValue()
        {
            this.MyProperty = 9;
        }
    }
