    static void Main(string[] args)
    {
        Console.WriteLine(nameof(args));
        Console.WriteLine("regular text");
    }
    // striped nops from the listing
    IL_0001 ldstr args
    IL_0006 call System.Void System.Console::WriteLine(System.String)
    IL_000C ldstr regular text
    IL_0011 call System.Void System.Console::WriteLine(System.String)
    IL_0017 ret
