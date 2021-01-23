    public static class MiscExtensions
    {
        public static Type GetCompileTimeType<T>(this T dummy)
        { return typeof(T); }
    }
    void Main()
    {
        object x = "this is actually a string";
        Console.WriteLine(x.GetType());
        Console.WriteLine(x.GetCompileTimeType());
    }
