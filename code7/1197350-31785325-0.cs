    public class Zoo : ConfigurationElement
    {
        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return (string)base["Name"]; }
        }
        [TypeConverter(typeof(AnimalConverter))]
        [ConfigurationProperty("Animals")]
        public IEnumerable<Animal> Animals
        {
            get { return (IEnumerable<Animal>)base["Animals"]; }
        }
    }
