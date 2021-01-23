    var assembly = Assembly.LoadFile("xxx.dll");
    
    var testClasses = assembly.GetTypes()
        .Where(c => c.GetCustomAttribute<TestClassAttribute>() != null);
    
    foreach (var testClass in testClasses)
    {
        Console.WriteLine("Found test class " + testClass.FullName);
    
        var testMethods = testClass.GetMethods().Where(m => m.GetCustomAttribute<TestMethodAttribute>() != null);
        foreach (var testMethod in testMethods)
        {
            Console.WriteLine("Found test method " + testMethod.Name);
        }
    }
