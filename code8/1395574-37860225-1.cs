    public void M()
    {
        this.Test(5m);
        this.Test(5m);
    }
    public void Test(decimal someValue)
    {
        decimal value = someValue * 5.5m;
        Console.WriteLine(value);
    }
