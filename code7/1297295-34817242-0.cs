    using Newtonsoft.Json;
    using System.Net;
    
    namespace Stackoverflow
    {
    
        public static class GetExternalIP
        {
            class IpAddress
            {
                public string ip { get; set; }
            }
            public static string GetExternalIp()
            {
    
                WebClient client = new WebClient();
    
                string jsonData = client.DownloadString("https://api.ipify.org/?format=json");
                IpAddress results = JsonConvert.DeserializeObject<IpAddress>(jsonData);
    
                string externalIp = results.ip;
    
                return externalIp;
            }
        }
    }
