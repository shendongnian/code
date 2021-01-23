    int[] old = new int[] { 1, 2, 3, 4, 5, 6 };
    int[] otherReference = old; // currently points to the same object
    
    Array.Resize(ref old, 3);
    
    Console.WriteLine("---- OTHER REFERENCE-----");
    
    for (int i = 0; i < otherReference.Length; i++)
    {
        Console.WriteLine(i);
    }
    
    Console.WriteLine("---- OLD -----");
    
    for (int i = 0; i < old.Length; i++)
    {
        Console.WriteLine(i);
    }
