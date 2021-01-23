    public class BiningInfo
    {
        
        public IPAddress IpAddress { get; set;}
        
        public int Port { get; set;} 
        
    }
    
    
    public List<BiningInfo> loadSocks()
    {
        var result = new List<BiningInfo>();
    
        var input = Path.GetFullPath(Path.Combine(Application.StartupPath, "Exploit1/socks-list.txt"));
        var r = new Regex(@"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}):(\d{1,5})");
        foreach (Match match in r.Matches(input))
        {
            string ip = match.Groups[1].Value;
            int port =  Convert.ToInt32(match.Groups[2].Value);
            
            BiningInfo bi = new BiningInfo();
            bi = IPAddress.Parse(ip);
            bi.Port = port;
        }
        return result;
    }
