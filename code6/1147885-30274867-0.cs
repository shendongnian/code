    interface MyInterface { }
    public static void Main()
    {
        Assembly asm = Assembly.Load("externalAssembly");
        var interfaces = asm.GetTypes().Where(t => t.IsSubclassOf(typeof(MyInterface)));
        
        foreach (var i in interfaces)
        {
            Console.WriteLine(String.Format("Found: {0}", i.Name));
        }
    }
