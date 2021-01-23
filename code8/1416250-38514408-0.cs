    /// <summary>
    /// Defines a generic custom configuration section with a collection of elements of type T.
    /// Reference: http://www.abhisheksur.com/2011/09/writing-custom-configurationsection-to.html
    /// </summary>
    public class GenericSection<T> : ConfigurationSection
        where T : ConfigurationElement, IConfigurationElement, new()
    {
    
        // Attribute argument must be a constant expression.
        protected const string _elementsTag = "elements";
    
        public GenericSection()
        {
        }
    
    
        [ConfigurationProperty(_elementsTag, Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public GenericElementCollection<T> Elements
        {
            get { return ((GenericElementCollection<T>)(base[_elementsTag])); }
            set { base[_elementsTag] = value; }
        }
    
    }
    
