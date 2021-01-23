    void Main()
    {
        typeof(Test).GetField("Value").GetValue(null).Dump();
        // Instance reference is null ----->----^^^^
    }
    
    public class Test
    {
        public const int Value = 42;
    }
