    public void M(int? x) 
    {
        object y = x;
        Console.WriteLine(y);
    }
    public void Main()
    {
        M(null);
    }
