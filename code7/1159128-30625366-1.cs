    static void Main(string[] args)
    {
        Dictionary<string, Func<Test, object>> MethodDictionary = new Dictionary<string,Func<Test,object>>();
        MethodDictionary.Add("Test1", TestMethod1);
        MethodDictionary.Add("Test2", TestMethod2);
        Test.MethodDictionary = MethodDictionary;
        var x = new Test() { Var1 = 20, Var2 = 30 };
        Console.WriteLine(Test.MethodDictionary["Test1"](x).ToString());
        Console.WriteLine(Test.MethodDictionary["Test2"](x).ToString());
        Console.ReadKey();
    }
