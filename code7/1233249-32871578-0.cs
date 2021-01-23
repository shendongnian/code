    [ConfigurationCollection(typeof(BundleElement))]
        internal class ResourceElement : ConfigurationElementCollection
        {
            internal const string TAG_NAME = "resource";
            private const string ATTR_TYPE = "type";
    
            [ConfigurationProperty(ATTR_TYPE, IsRequired = true, IsKey = true)]
            internal string Type
            {
                get { return base[ATTR_TYPE] as string; }
                set { base[ATTR_TYPE] = value; }
            }
    
            protected override string ElementName { get { return BundleElement.TAG_NAME; } }
    
            public override ConfigurationElementCollectionType CollectionType
            {
                get {return  ConfigurationElementCollectionType.BasicMap;}
            }
           
            protected override ConfigurationElement CreateNewElement()
            {
                return new BundleElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((BundleElement)element).Name;
            }
        }
     [ConfigurationCollection(typeof(FileElement))]
        internal class BundleElement : ConfigurationElementCollection
        {
            internal const string TAG_NAME = "bundle";
            private const string ATTR_NAME = "name";
        [ConfigurationProperty(ATTR_NAME, IsRequired = true, IsKey = true)]
        internal string Name
        {
            get { return this[ATTR_NAME] as string; }
            set { this[ATTR_NAME] = value; }
        }
        protected override string ElementName { get { return FileElement.TAG_NAME; } }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileElement)element).Path;
        }  
    }
