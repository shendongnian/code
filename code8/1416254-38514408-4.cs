    /// <summary>
    /// Defines a configuration folder
    /// </summary>
    public class FolderElement : ConfigurationElement, IConfigurationElement
    {
        protected const string NameKey = "name";
        protected const string VolumeKey = "volume";
        protected const string PathKey = "path";
    
        [ConfigurationProperty(NameKey, DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base[NameKey]; }
            set { base[NameKey] = value; }
        }
    
        [ConfigurationProperty(VolumeKey, DefaultValue = "", IsKey = false, IsRequired = false)]
        public string VolumeLabel
        {
            get { return (string)base[VolumeKey]; }
            set { base[VolumeKey] = value; }
        }
    
        [ConfigurationProperty(PathKey, DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Path
        {
            get { return (string)base[PathKey]; }
            set { base[PathKey] = value; }
        }
    
        [ConfigurationProperty("active", DefaultValue = "true", IsKey = false, IsRequired = false)]
        public bool Active
        {
            get { return (bool)base["active"]; }
            set { base["active"] = value; }
        }
    }
