            public IList<WemoDevice> GetWemoIPs()
            {
                var wemos = new List<WemoDevice>();
    
                Parallel.For(1, 255, (i) =>
                {
                    var ip = string.Format(this.IpFormat, i);
                    var device = new WemoDevice(ip);
    
                    if (IsWemo(ip))
                        wemos.Add(device);
                });
    
    
                return wemos;
            }       
    
            public bool IsWemo(string ipAddress)
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    try
                    {
                        tcpClient.Connect(ipAddress, 49153);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
