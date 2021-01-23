    public class ConfigManager
    {
        private readonly IDictionary<string, string> m_Dictionary;
        public ConfigManager(IDictionary<string, string> dictionary)
        {
            m_Dictionary = dictionary;
        }
        public string IPAddress
        {
             get
             {
                 if (m_Dictionary.ContainsKey("IPAddr"))
                    return m_Dictionary["IPAddr"];
                 return null;
             }
             set
             {
                 if (m_Dictionary.ContainsKey("IPAddr"))
                     m_Dictionary.Remove("IPAddr");
                 m_Dictionary.Add("IPAddr", value);
             } 
        }
