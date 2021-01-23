    static public bool UsageHasKeyEncipherment(X509Certificate2 tmpCert)
    {
        foreach (X509KeyUsageExtension usage_extension in tmpCert.Extensions.OfType<X509KeyUsageExtension>())
        {
            if ((usage_extension.KeyUsages & X509KeyUsageFlags.KeyEncipherment) == X509KeyUsageFlags.KeyEncipherment)
            {
                return true;
            }
        }
        return false;
    }
