    Assembly dll = Assembly.LoadFile(@"C:\YourDirectory\YourAssembly.dll");
    foreach (Type type in dll.GetTypes())
    {
        var details = string.Format("Namespace : {0}, Type : {1}", type.Namespace, type.Name);
        //write details to your log file here...
        Console.WriteLine(details);
        foreach (var method in type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public))
        {
            var methodDetails = string.Format("{0} {1}({2})", method.ReturnParameter, method.Name, 
                                                string.Join(",", method.GetParameters().Select(p => p.ParameterType.Name)));
            //write methodDetails to your log file here...
            Console.WriteLine("\t" + methodDetails);
        }
    }
