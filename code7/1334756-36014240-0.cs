    void Main()
    {
        string[] words = 
        {
            "123Hi1234Howdy", 
            "Hi1Howdy23"
        };
    
        var bArrays = words.Select(w => new BitArray(w.Select(c => char.IsDigit(c)).ToArray()));
    
    }
