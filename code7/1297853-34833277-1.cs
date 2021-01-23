    class Program
    {
        static void Main(string[] args)
        {
            Test<ITestable>.CreateTestFile("test.txt");
        }
    }
    class Test<T> where T : ITestable
    {
         public static void CreateTestFile(String fileName) { }
    }
    
    public interface ITestable { }
