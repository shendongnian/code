    public class MyClass
    {
        public int Value { get; set; }
    }
    
    public static async Task<int> DivideAsync(MyClass myClass)
    {
        await Task.Yield();
        return 2 / myClass.Value;
    }
    
    public static Task<int> TestAsync()
    {
        MyClass myClass = new MyClass { Value = 4 };
        Task<int> result = DivideAsync(myClass);
        myClass.Value = 0;
        return result;
    }
