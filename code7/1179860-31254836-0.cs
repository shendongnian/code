    public static void MessageOrException(Union<string, ArgumentException> value)
    {
        value.Match().Case1().Do(Console.WriteLine)
                     .Else(Console.WriteLine("Exception")
                     .Exec();
    }
    public static void Main (string[] args)
    {
        Console.WriteLine ("Start");
        var example1 = new Union<string, ArgumentException> ("Str argument");
        MessageOrException(example1);  // Writes "Str argument"
   
        var example2 = 
            new Union<string, ArgumentException>(new ArgumentException("An exception"));
        MessageOrException(example2); // Writes "Exception"
        Console.WriteLine ("Done");
        Console.ReadLine ();
    }
