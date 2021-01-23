    void Main()
    {
    	Verify("hello", null);
    }
    
    public bool Verify(string blacklist, string message)
    {
        if (string.IsNullOrEmpty(blacklist)) return true;
        var split = blacklist.ToLower().Split(';'); // exception is thrown here
        return !split.Any(message.Contains);
    }
