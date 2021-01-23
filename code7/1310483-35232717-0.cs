    private static List<SocksWebProxy> proxies = new List<SocksWebProxy>();
    public static void MultipleProxy()
    {
        for (int i = 1; i <= 10; i++)
        {
            proxies.Add(Proxy(i));
        }
    }
