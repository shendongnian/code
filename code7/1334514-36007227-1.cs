     [ConfigurationCollection(typeof(KeyValue), AddItemName = "KeyValue")]
    public class KeyValueCollection : ConfigurationElementCollection
    { 
            get { return base.BaseGet(index) as KeyValue; }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
    }
    
