    class Program
    {
        static void Main(string[] args)
        {
            Util.CreateTestFile("test.txt");
        }
    }
    class Util
    {
        public static void CreateTestFile(String fileName) { }
    }
    class Test<T> where T : class, ITestable, new()
    {
        /*...*/
    }
    
    public interface ITestable { }
