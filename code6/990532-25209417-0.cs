    public ProxyGivenEventArgs : EventArgs
    {
        public ProxyName { get; private set; }
        public ProxyGivenEventArgs(String proxyName) 
        {
            this.ProxyName  = proxyName;
        }
    }
    
    static class Proxy
    {
        // ...
        
        public static event EventHandler<ProxyGivenEventArgs> ProxyGiven;
        private static OnProxyGiven(String proxyName)
        {
            if (Proxy.ProxyGiven != null)
                Proxy.ProxyGiven(null, new ProxyGivenEventArgs(proxyName));
        } 
        
    
        public static WebProxy GetProxy()
        {
            string[] proxy = proxies[proxyIndex].Split(':');
            WebProxy wp = new WebProxy(proxy[0], Convert.ToInt32(proxy[1]));
            
            OnProxyGiven(proxy[0]);
            
            return wp;
        }
        // ...
    }
