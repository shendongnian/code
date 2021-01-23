    public class SiteCollection : ConfigurationElementCollection
    {
        // Constructor
        public SiteCollection() { }
        public SiteElement this[int index]
        {
            get { return (SiteElement)BaseGet(index);  }
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
            return new SiteElement();
        }       // end of protected override ConfigurationElement CreateNewElement()
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SiteElement)element).name;
        }
    }           // end of public class SiteCollection : ConfigurationElementCollection
