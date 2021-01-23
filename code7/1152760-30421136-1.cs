    Console.WriteLine("Hello World");
    // First, save the standard output.
    var oldConsoleWriter = Console.Out;
    using(var stream = new FileStream("Test.txt", FileMode.Create))
    using(var writer = new StreamWriter(stream))
    {  
      Console.SetOut(writer);
      Console.WriteLine("Hello file");
    }
    Console.SetOut(oldConsoleWriter);
    Console.WriteLine("Hello World");
