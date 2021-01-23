    var info = Console.ReadKey();
    if (info.Key == ConsoleKey.R)
    {
         var fileName = Assembly.GetExecutingAssembly().Location;
         System.Diagnostics.Process.Start(fileName);
    }
