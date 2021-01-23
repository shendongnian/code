    public class ConfigurationCollection
    {
        public int ConfigurationCollectionID { get; set; }
        public string CollectionName { get; set; }
    
        public virtual ICollection<OptionValue> OptionValues { get; set; }
    }
    public class OptionValue
    {
        public int OptionValueID { get; set; }
        public string OptionVal { get; set; }
       
        public virtual ICollection<ConfigurationCollection> ConfigurationCollections { get; set; }
    }
