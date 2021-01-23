    static void Main(string[] args)
    {
        SomeWeirdClass original = new SomeWeirdClass(new[] { 5, 1, 4, 3, 2 });
    
        Console.WriteLine("Original Data: ");
        foreach (var item in original.Elements)
            Console.Write(item + " ");
        Console.WriteLine();
    
        SomeWeirdClass copy = original.Sort();
    
        Console.WriteLine("Original Data after Sort and Assignment: ");
        foreach (var item in original.Elements)
            Console.Write(item + " ");
        Console.WriteLine();
    
        Console.WriteLine("Sorted Copy:");
        foreach (var item in copy.Elements)
            Console.Write(item + " ");
        Console.WriteLine();
    
        original.Sort();
    
        Console.WriteLine("Original Data after Sort without Assignment: ");
        foreach (var item in original.Elements)
            Console.Write(item + " ");
        Console.WriteLine();
    }
