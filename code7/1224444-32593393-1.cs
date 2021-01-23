    public bool Verify(string blacklist, string message)
    {
        if (string.IsNullOrEmpty(blacklist)) return true;
        if (string.IsNullOrEmpty(message) return false;
        var split = blacklist.ToLower().Split(';'); // exception is thrown here
        return !split.Any(message.Contains);
    }
