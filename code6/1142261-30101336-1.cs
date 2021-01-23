    var assembly = Assembly.GetExecutingAssembly();
    foreach (var controller in assembly.GetTypes().Where(a => a.Name.EndsWith("Controller"))
    {
        Console.WriteLine(controller.Name.TrimEnd("Controller"));
    }
