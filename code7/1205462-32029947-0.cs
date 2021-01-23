    static void Main(string[] args)
    {
        var foo = new Foo()
        {
            Property1 = "Value1",
            Property2 = "Value2"
        };
        var bar = Mapper.Map<Bar>(foo);
        bar.Id = 3;
        Console.WriteLine(bar.Id); //3
        Console.WriteLine(bar.Property1); //Value1
        Console.WriteLine(bar.Property2); //Value2
    }
