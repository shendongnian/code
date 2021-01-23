    // <sswcomm></sswcomm> settings
    public class SSWConfigSSWComm : ConfigurationSection
    {
        [ConfigurationProperty("id")]
        public string Id
        {
            get { return (string)this["id"]; }
            set { this["id"] = value; }
        }
        [ConfigurationProperty("connectionInterval")]
        public int ConnectionInterval
        {
            get { return (int)this["connectionInterval"]; }
            set { this["connectionInterval"] = value; }
        }
        [ConfigurationProperty("toPath")]
        public string ToPath
        {
            get { return (string)this["toPath"]; }
            set { this["toPath"] = value; }
        }
        [ConfigurationProperty("folders")]
        [ConfigurationCollection(typeof(SSWConfigFolderElement), AddItemName = "folder")]
        public SSWConfigFolderElementCollection sswConfigFolders
        {
            get { return (SSWConfigFolderElementCollection)base["folders"]; }
        }
    }
    // <folder> settings
    [ConfigurationCollection(typeof(SSWConfigFolderElement))]
    public class SSWConfigFolderElementCollection : ConfigurationElementCollection
    {
        new public SSWConfigFolderElement this[string name]
        {
            get { return (SSWConfigFolderElement)base.BaseGet(name); }
        }
        public SSWConfigFolderElement this[int index]
        {
            get { return (SSWConfigFolderElement)base.BaseGet(index); }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new SSWConfigFolderElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SSWConfigFolderElement)element).Id;
        }
    }
    public class SSWConfigFolderElement : ConfigurationElement
    {
        [ConfigurationProperty("id")]
        public string Id
        {
            get { return (string)base["id"]; }
            set { base["id"] = value; }
        }
        [ConfigurationProperty("enable")]
        public bool Enable
        {
            get { return (string)base["enable"] == "true"; }
            set { if (value) { base["enable"] = "true"; } else { base["enable"] = "false"; } }
        }
        [ConfigurationProperty("includeSubFolders")]
        public bool IncludeSubFolders
        {
            get { return (string)base["includeSubFolders"] == "true"; }
            set { if (value) { base["includeSubFolders"] = "true"; } else { base["enable"] = "false"; } }
        }
        [ConfigurationProperty("fromPath")]
        public string FromPath
        {
            get { return (string)base["fromPath"]; }
            set { base["fromPath"] = value; }
        }
        [ConfigurationProperty("wildcard")]
        public string Wildcard
        {
            get { return (string)base["wildcard"]; }
            set { base["wildcard"] = value; }
        }
        [ConfigurationProperty("recipientId")]
        [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 256)]
        public string RecipientId
        {
            get { return (string)base["recipientId"]; }
            set { base["recipientId"] = value; }
        }
    }
