    [Obsolete]
    public class MyClass
    {
    }
    public static void Test1(MyClass test2) // This line has a warning
    {
        var y = test2; // ***This line doesn't have a warning***
        MyClass z = test2; // This line has a warning
    }
