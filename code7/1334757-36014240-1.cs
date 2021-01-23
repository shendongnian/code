    void Main()
    {
        string[] words = 
        {
            "123Hi1234Howdy", 
            "Hi1Howdy23"
        };
    
        //Create an array of BitArray
        var bArrays = words.Select(w => new BitArray(w.Select(c => char.IsDigit(c)).ToArray()));
        //You can also create string too
        var strings = words.Select(w => new string(w.Select(c => char.IsDigit(c) ? '1' : '0').ToArray())).ToArray();
    
    }
