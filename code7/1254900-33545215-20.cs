    public class ConfigurationCollection
    {
        //...
        //public virtual ICollection<OptionValue> OptionValues { get; set; }
        public virtual ICollection<Config_OptionVal> OptionValues { get; set; }
    }
    public class OptionValue
    {
       //...
       //public virtual ICollection<ConfigurationCollection> ConfigurationCollections { get; set; }
       public virtual ICollection<Config_OptionVal> ConfigurationCollections { get; set; }
       
    }
