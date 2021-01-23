    public void Log(string message, DateTime? timestamp = null)
    {
        DateTime actualTimestamp = timestamp ?? DateTime.UtcNow;
        ...
    }
