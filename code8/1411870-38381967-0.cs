    class Program
    {
        static void Main(string[] args)
        {
            var obj = new object(); // Replace here with your object 
    
            // Parse the method name to call
            var command = Console.ReadLine();
            var methodName = command.Substring(command.LastIndexOf('.')+1).Replace("(", "").Replace(")", "");
    
            // Use reflection to get the Method
            var type = obj.GetType();
            var methodInfo = type.GetMethod(methodName);
    
            // Invoke the method here
            methodInfo.Invoke(obj, null);
        }
    }
