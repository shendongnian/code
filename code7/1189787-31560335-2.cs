    public static int Compare(byte[] x, byte[] y)
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
        byte[] bytesFrom = from.GetAddressBytes();
        byte[] bytesTo = to.GetAddressBytes();
        while (Compare(bytesFrom, bytesTo) <= 0)
        {
            yield return new IPAddress(bytesFrom);
            for (int i = bytesFrom.Length - 1; i >= 0; i--)
            {
                if (bytesFrom[i] != 0xFF)
                {
                    bytesFrom[i]++;
                    break;
                }
                bytesFrom[i] = 0;
            }
        }
    }
