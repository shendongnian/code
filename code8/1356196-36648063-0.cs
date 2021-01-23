    class Program
    {
        static void Main(string[] args)
      {
         //Get type of class by name
         Type classType = Assembly.GetExecutingAssembly().GetType("TestAlexander.Test");
         //Create instance of the class
         var instance = Activator.CreateInstance(classType);
         //Invoke the generic method
         classType.GetMethod("TestMethod").MakeGenericMethod(classType).Invoke(instance, null);
         Console.Read();
      }
    }
    public class Test
    {
        public void TestMethod<T>()
        {
            Console.WriteLine("Great succes!");
        }
    }
