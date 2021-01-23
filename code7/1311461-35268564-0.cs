    private FirefoxDriver _CreateFirefoxDriver(string socksProxy)
    {
        if (string.IsNullOrEmpty(socksProxy))
        {
            return new FirefoxDriver();
        }
    
        var caps = new DesiredCapabilities();
        caps.SetCapability(CapabilityType.Proxy, new Proxy { SocksProxy = socksProxy });
        return new FirefoxDriver(caps);
    }
