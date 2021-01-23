    class Program
    {
        static void Main(string[] args)
        {
            Test<object>.CreateTestFile("test.txt");
        }
    }
    class Test<T> where T : class, new()
    {
         public static void CreateTestFile(String fileName) { }
    }
    
    public interface ITestable { }
