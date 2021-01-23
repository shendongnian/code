    [Flags]
    public enum Keys1
    {
        O = 0,
        K = 1,
        A = 1 << 1,
        Y = 1 << 2
    }
    
    public enum Keys2
    {
        O,
        K,
        A,
        Y
    }
    public bool DoesIncludeKey(Keys1 keys1, Keys2 keys2)
    {
        var keys1Names = keys1.ToString().Split(',');
        return keys1Names.Contains(keys2.ToString());
    }
    
    //ToString() on keysVals results in "O,K", 
    //which is what makes the above function work.
    var keysVals = Keys1.O | Keys1.K;
    
    //true!
    var includesK = DoesIncludeKey(keysVals, Keys2.K);
    //false.
    var includesA = DoesIncludeKey(keysVals, Keys2.A);
