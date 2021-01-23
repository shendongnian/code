    [ConfigurationCollection(typeof(MyConfigElement), AddItemName = "ConfigElement"]
    public class MyConfigElementCollection : ConfigurationElementCollection
    {
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
    }
