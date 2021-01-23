    class MyClass
    {
        public int MyProperty { get; set; }
    }
    static void Main(string[] args)
    {
        var list = Enumerable.Range(1, 50).Select(x => new MyClass { MyProperty = x });
        var expression = new CompiledExpression<bool>("MyProperty > 10");
        var func = expression.ScopeCompile<MyClass>();
        var filtered = list.Where(p => func(p));
        Console.WriteLine(filtered.Count()); //40
        Console.ReadLine();
    }
