    public class ProxyGivenEventArgs : EventArgs
    {
        public WebProxy ProxyInstance { get; private set; }
        public ProxyGivenEventArgs(WebProxy proxy) 
        {
            this.ProxyInstance = proxy;
        }
    }
    //...
    private static void OnProxyGiven(WebProxy proxy)
    {
        if (Proxy.ProxyGiven != null)
            Proxy.ProxyGiven(null, new ProxyGivenEventArgs(proxy));
    } 
    public static WebProxy GetProxy()
    {
        string[] proxy = proxies[proxyIndex].Split(':');
        WebProxy wp = new WebProxy(proxy[0], Convert.ToInt32(proxy[1]));
            
        OnProxyGiven(wp);
            
        return wp;
    }
