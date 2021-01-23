      public class RMSNetUtils
      {
        private static string _linkagePath = @"SYSTEM\CurrentControlSet\Services\Tcpip\Linkage";
    
        private static string _interfacesPath = @"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\";
    
        private static List<string> GetBindingsPriority()
        {
          using (var bindMasterKey = Registry.LocalMachine.OpenSubKey(_linkagePath))
          {
            var bind = (string[]) bindMasterKey.GetValue("Bind");
            var deviceList = bind.Select(x => $@"{_interfacesPath}{x.Replace("\\Device\\", string.Empty)}")
              .ToList();
    
            var result = new List<string>();
    
            foreach (var device in deviceList)
            {
              using (var bindKey = Registry.LocalMachine.OpenSubKey(device))
              {
                var fixIP = (string[])bindKey.GetValue("IPAddress");
                if (fixIP != null)
                {
                  result.Add( fixIP.FirstOrDefault());
                  continue;
                }
    
                var dhcpIp = bindKey.GetValue("DhcpIPAddress");
                if (dhcpIp != null)
                {
                  result.Add((string) dhcpIp);
                }
              }
            }
            return result;
          }
        }
    
        private static List<NICInformation> GetFilteredBindings()
        {
          var bindings = GetBindingsPriority();
          var nicsInfo = GetIpList(GetInterNetworkAdapters());
          var result = new List<NICInformation>();
          foreach (var bind in bindings)
          {
            var nicInfo = nicsInfo.FirstOrDefault(y => string.Compare(y.IPv4, bind) == 0);
            if(nicInfo!= null)
              result.Add(nicInfo);
          }
    
          return result;
        }
    
        private static IEnumerable<IPAddress> GetInterNetworkAdapters()
        {
          IPHostEntry local = Dns.GetHostEntry(string.Empty);
          return (from ipa in local.AddressList
            where ipa.AddressFamily == AddressFamily.InterNetwork
            select ipa);
        }
    
        public static string GetFirstIpv4Ip()
        {
          return GetFirstIpv4Ip(String.Empty);
        }
    
        private static List<NICInformation> GetIpList(IEnumerable<IPAddress> ips)
        {
          var ipAddresses = ips.Select(x => x.ToString()).ToList();
          var result = new List<NICInformation>();
    
          foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
          {
            if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
              foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
              {
                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                  var ipStr = ip.Address.ToString();
                  if (ipAddresses.Contains(ipStr))
                  {
                    var nic = new NICInformation();
                    nic.IPv4 = ip.Address.ToString();
                    nic.Mask = ip.IPv4Mask.ToString();
                    nic.DnsSuffix = ni.GetIPProperties().DnsSuffix;
                    var gateway = ni.GetIPProperties().GatewayAddresses.FirstOrDefault();
                    if(gateway!=null)
                      nic.Gateway = gateway.Address.ToString();
                    result.Add(nic);
                  }
                }
              }
            }
          }
    
          return result;
        }
    
        public static string GetTopIpv4Ip(string hostName)
        {
          if (!string.IsNullOrEmpty(hostName))
            return GetFirstIpv4Ip(hostName);
          var item = GetFilteredBindings().FirstOrDefault();
    
          return item == null ? hostName : item.IPv4;
        }
        
        public static string GetFirstIpv4Ip(string hostName)
        {
          var ip = string.Empty;
          try
          {
            IPHostEntry local = Dns.GetHostEntry(hostName);
            var result = GetInterNetworkAdapters().FirstOrDefault();
    
            return result != null ? result.ToString() : hostName;
          }
          catch (SocketException ex)
          {
            ip = hostName;
          }
    
          return ip;
        }
      }
    
      public class NICInformation
      {
        public string DnsSuffix {get;set;}
        public string IPv4 {get;set; }
    
        public string Gateway {get;set;}
    
        public string Mask {get;set;}
      }
