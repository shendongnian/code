    public int DummyMethod(int retries = 0)
    {
        string token;
        try 
        {
            token = GetNewToken();
            return GetResultFromWebSite(token);
        }
        catch (Exception e)
        {
            if (retries < 4) // or whatever max you want - you probably shouldn't hardcode it
            {
                return DummyMethod(++retries);
            }
            throw new Exception("Server ain't responding");
        }
    }
