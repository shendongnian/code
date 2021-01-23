    public class ConfigElementCollection: ConfigurationElementCollection
        {
            public override ConfigurationElementCollectionType CollectionType
            {
                get { return ConfigurationElementCollectionType.BasicMap; }
            }
    
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new MyConfigElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                if (element == null)
                    throw new ArgumentNullException("element");
    
                return ((MyConfigElement)element).key;
    
            }
    
            protected override string ElementName
            {
                get { return "ConfigElement "; }
            }
        }
