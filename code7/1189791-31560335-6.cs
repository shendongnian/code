    public static IEnumerable<IPAddress> FromTo(IPAddress from, IPAddress to)
    {
        if (from == null || to == null)
        {
            throw new ArgumentNullException(from == null ? "from" : "to");
        }
        if (from.AddressFamily != to.AddressFamily)
        {
            throw new ArgumentException("from/to");
        }
        long scopeId;
        // ScopeId can be used only for IPv6
        if (from.AddressFamily == AddressFamily.InterNetworkV6)
        {
            if (from.ScopeId != to.ScopeId)
            {
                throw new ArgumentException("from/to");
            }
            scopeId = from.ScopeId;
        }
        else
        {
            scopeId = 0;
        }
 
        byte[] bytesTo = to.GetAddressBytes();
        for (byte[] bytesFrom = from.GetAddressBytes(); 
             Compare(bytesFrom, bytesTo) <= 0; 
             Increment(bytesFrom))
        {
            if (scopeId != 0)
            {
                // This constructor can be used only for IPv6
                yield return new IPAddress(bytesFrom, scopeId);
            }
            else
            {
                yield return new IPAddress(bytesFrom);
            }
        }
    }
    private static int Compare(byte[] x, byte[] y)
    {
        for (int i = 0; i < x.Length; i++)
        {
            int ret = x[i].CompareTo(y[i]);
            if (ret != 0)
            {
                return ret;
            }
        }
        return 0;
    }
    private static void Increment(byte[] x)
    {
        for (int i = x.Length - 1; i >= 0; i--)
        {
            if (x[i] != 0xFF)
            {
                x[i]++;
                return;
            }
            x[i] = 0;
        }
    }
