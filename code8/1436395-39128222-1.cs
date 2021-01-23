    Console.WriteLine("Properties of System.Type are:");
    foreach (PropertyInfo myPropertyInfo in typeof(MyClass).GetProperties())
    {
        Console.WriteLine(myPropertyInfo.ToString());
    }
