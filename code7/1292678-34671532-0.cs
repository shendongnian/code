    void Main()
    {
        Console.WriteLine(MethodSignature((Func<bool, bool, bool>)testFunc));
        Console.WriteLine(MethodSignature((Action<bool, bool[]>)testAction));
    }
    bool testFunc(bool a, bool b) => a || b;
    void testAction(bool a, bool[] b) { };
