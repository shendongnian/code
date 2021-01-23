    public class MenuConfig : ConfigurationElement
      {
        public MenuConfig () {}
    
        public MenuConfig (bool enabled, string description)
        {
          Enabled = enabled;
          Description = description;
        }
    
        [ConfigurationProperty("Enabled", DefaultValue = false, IsRequired = true, IsKey = 
    
    true)]
        public bool Enabled
        {
          get { return (bool) this["Enabled"]; }
          set { this["Enabled"] = value; }
        }
    
        [ConfigurationProperty("Description", DefaultValue = "no desc", IsRequired = true, 
    
    IsKey = false)]
        public string Description
        {
          get { return (string) this["Description"]; }
          set { this["Description"] = value; }
        }
      }
