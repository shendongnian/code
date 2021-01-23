    public int DummyMethod()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        string token = GetNewToken();
        int result;
        do
        {
            if (stopwatch.Elapsed.TotalSeconds >= 350) {
                token = GetNewToken();
                stopwatch.Restart();
            }
    
            result = GetResultFromWebSite(token);
        } while (result == -1);
    
        return result;
    }
