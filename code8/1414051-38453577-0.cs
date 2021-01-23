    int[] old = new int[] { 1, 2, 3, 4, 5, 6 };
    int[] oldRef = old;
    
    
    Array.Resize(ref old, 3);
    
    for (int i = 0; i < oldRef.Length; i++)
    {
        Console.WriteLine(i);
    }
