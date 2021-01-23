    static void Main(string[] args)
        {
            object test=  Activator.CreateInstance(typeof(SafeClass));     
            MethodInfo definition = typeof(SafeClass).GetMethod("Print");
            MethodInfo constructed = definition.MakeGenericMethod(typeof(int));
            constructed.Invoke(test, null);
            Console.ReadLine();
        }
