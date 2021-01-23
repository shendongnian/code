    /// <summary>
    /// Get the accurate NY Time value
    /// </summary>
    /// <returns>DateTime</returns>
    protected DateTime GetTimeNYC()
    {
        try { return DateTime.Now.ToUniversalTime().AddHours(_offsetHour); }
        catch { throw; }
    }
