    static void NewElement(string EleWeight)
    {
        ...
    }
    
    static void ElementData(string EleName, string EleSymbol, string EleNumber, string EleWeight)
    {
        Console.WriteLine("Element: " + EleName);
        Console.WriteLine("Symbol: " + EleSymbol);
        Console.WriteLine("Atomic Number: " + EleNumber);
        Console.WriteLine("Atomic Weight: " + EleWeight);
        NewElement(EleWeight);
    }
