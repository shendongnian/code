    [ConfigurationCollection(typeof(Feature), AddItemName = "Feature")]
    public class FeatureCollection : ConfigurationElementCollection
    {
        public Feature this[int index]
        {
            get { return (Feature)BaseGet(index); }
            set 
            {
                if(BaseGet(index) !=  null)
                {
                    BaseRemoveAt(index);
                }
            
                BaseAdd(index,value);
            }
        }
    
        protected override ConfigurationElement CreateNewElement()
        {
            return new Feature();
        }
    
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Feature)element);
        }
    }
