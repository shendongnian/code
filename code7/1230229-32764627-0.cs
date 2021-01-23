      class Program
      {
        static void Main(string[] args)
        {
          var instance = new AClassWithHundredsOfMethods();
          var result = InvokeMethodWithParams<AClassWithHundredsOfMethods>(instance, "INSERT_NEW_RECORD", "MyFirstName", "MyLastName", "MyMiddleInitial");
          Console.WriteLine(result);
        }
    
    
        static object InvokeMethodWithParams<T>(object instance, string methodName, params object[] parameters) where T : class
        {
          return  typeof(T).GetMethod(methodName).Invoke(instance, parameters);
        }
      }
