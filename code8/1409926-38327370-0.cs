    public class ConfigManager : Dictionary<string, string>
    {
        public string IPAddress
        {
             get
             {
                 if (ContainsKey("IPAddr"))
                     return this["IPAddr"];
                 return null;
             }
             set
             {
                 if (ContainsKey("IPAddr"))
                     Remove("IPAddr");
                 Add("IPAddr", value);
             } 
        }
