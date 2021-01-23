    string GetSubDomain(Uri url, string defaultValue)
    {
        string subdomain = defaultValue;
        if (url.HostNameType == UriHostNameType.Dns)
        {
            string host = url.Host;
            if (host.Split('.').Length > 2)
            {
                int index = host.IndexOf(".");
                int lastIndex = host.LastIndexOf(".");
                subdomain = index.Equals(lastIndex) ? defaultValue : host.Substring(0, index);
            }
        }
        return subdomain;
    }
