    var dll = Assembly.LoadFile(@"D:\Trabalho\Temp\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe");
    var logItems = dll.GetTypes()
        .SelectMany(t => t.GetMethods(), Tuple.Create)
        .OrderBy(t => t.Item1.Namespace)
        .ThenBy(t => t.Item1.Name)
        .ThenBy(t => t.Item2.Name)
        .Select(t => $"{"ConsoleApplication1"}~{t.Item1.FullName}~{t.Item2.Name}({string.Join(", ", t.Item2.GetParameters().Select(p => p.ParameterType.Name))})");
    Console.WriteLine(string.Join(Environment.NewLine, logItems));
