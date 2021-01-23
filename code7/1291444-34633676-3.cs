    void Main()
    {
        Test(() => new Child1(42));
        Test(() => new Child2("Meaning of life"));
    }
    
    public void Test(Func<Base> baseFactory)
    {
        Console.WriteLine("In Test(...");
        var b = baseFactory();
    }
