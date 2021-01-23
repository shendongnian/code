    public class SiteSettingsElementCollection : ConfigurationElementCollection
    {
        // Constructor
        public SiteSettingsElementCollection() { }
        public SiteSettingElement this[int index]
        {
            get { return (SiteSettingElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }       // end of public SiteElement this[int index]
        protected override ConfigurationElement CreateNewElement()
        {
            return new SiteSettingElement();
        }       // end of protected override ConfigurationElement CreateNewElement()
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SiteSettingElement)element).name;
        }
    }           // end of public class SiteCollection : ConfigurationElementCollection
