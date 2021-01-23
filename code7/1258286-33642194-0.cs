    public static bool IsValidIP(string address)
    {
        IPAddress ip;
        if (!IPAddress.TryParse(address, out ip)) return false;
        switch (ip.AddressFamily)
        {
            case AddressFamily.InterNetwork:
                if (address.Length > 6 && address.Contains("."))
                {
                    string[] s = address.Split('.');
                    if (s.Length == 4 && s[0].Length > 0 && s[1].Length > 0 && s[2].Length > 0 && s[3].Length > 0)
                        return true;
                }
                break;
            case AddressFamily.InterNetworkV6:
                if (address.Contains(":") && address.Length > 15)
                    return true;
                break;
        }
        return false;
    }
