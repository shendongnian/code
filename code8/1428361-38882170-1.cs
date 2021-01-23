    Assembly assembly = Assembly.LoadFrom(@"D:\Library\CurrencyData.dll");
    List<AYClass> listObjects = new List<AYClass>();
    foreach (Type type in assembly.GetExportedTypes())
    {
        if (type.BaseType.ToString().Contains("AYClass"))
        {
            var c = (AYClass)Activator.CreateInstance(type);
            listObjects.Add(c);
        }
    }
