    using MyDll;
    static void Main(string[] args)
    {
        var obj = new MyClass();
        var txt = obj.GetText();
        Console.WriteLine(txt);
    }
