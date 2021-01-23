    void Main()
    {
        var t = new Test();
        InvokeFunction<int>(t, "Add", 10, 20).Dump();
        InvokeFunction<int>(t, "Negate", 10).Dump();
        InvokeFunction<int>(t, "SemiRandom").Dump();
    }
    
    public class Test
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    
        public int Negate(int value)
        {
            return -value;
        }
    
        public int SemiRandom()
        {
            return new Random().Next();
        }
    }
    
    public static T InvokeFunction<T>(object instance, string methodName, params object[] arguments)
    {
        var method = instance.GetType().GetMethod(methodName, arguments.Select(a => a.GetType()).ToArray());
        return (T)method.Invoke(instance, arguments);
    }
