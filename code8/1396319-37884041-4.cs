    static void Main(string[] args)
    {
        SomeWeirdClass original = new SomeWeirdClass(new[] { 5, 1, 4, 3, 2 });
    
        Console.WriteLine("Original Data: ");
        Console.WriteLine(string.Join(" ", original.Elements));
    
        SomeWeirdClass copy = original.Sort();
    
        Console.WriteLine("Original Data after Sort and Assignment: ");
        Console.WriteLine(string.Join(" ", original.Elements));
    
        Console.WriteLine("Sorted Copy:");
        Console.WriteLine(string.Join(" ", copy.Elements));
    
        original.Sort();
    
        Console.WriteLine("Original Data after Sort without Assignment: ");
        Console.WriteLine(string.Join(" ", original.Elements));
    }
