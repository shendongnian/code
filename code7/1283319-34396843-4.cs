    static void Main(string[] args)
    {
        A test = new B();
        
        new B().Id = 3;
        new A().Id = 2;
        test.Id = 1;
        Console.WriteLine(test.Id + " " + new B().Id + " " + new A().Id);
        Console.ReadKey();
    }
