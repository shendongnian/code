    class Program
    {
       static void Main(string[] args)
       {
         Type classType = Assembly.GetExecutingAssembly().GetType("RandomTestShit.Test");
         Test test = new Test();
         typeof(Test).GetMethod("TestMethod").MakeGenericMethod(classType).Invoke(test, null);
         Console.Read();
       }
    }
    public class Test
    {
        public void TestMethod<T>() where T: class
        {
            Console.WriteLine("Great success!");
        }
    }
