    public void Start()
    {
        Var1 = new TestClass("Me", 1);
        Var2 = new TestClass();           // You would need a default constructor, and to use it to prevent the null exception error
        Var2.TestNumber = Var1.TestNumber;
        Var2.TestName   = "aaa";
    
    }
