    /// <summary>
    /// Defines a generic ConfigurationElementCollection
    /// </summary>
    [ConfigurationCollection(typeof(IConfigurationElement))]
    public class GenericElementCollection<T> : ConfigurationElementCollection
        where T : ConfigurationElement, IConfigurationElement, new()
    {
        internal const string _elementName = "elements";
    
        protected override string ElementName
        {
            get { return _elementName; }
        }
    
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
    
        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(_elementName, StringComparison.InvariantCultureIgnoreCase);
        }
    
        public override bool IsReadOnly()
        {
            return false;
        }
    
        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }
    
        /// <summary>
        /// Return key value for element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((T)element).Name;
        }
    
        /// <summary>
        /// Default index property.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]  // #c160704 was IConfigruationElement
        {
            get { return (T)BaseGet(index); }
        }
    
    
        /// <summary>
        /// Returns content element by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetElementByName(string name)
        {
            return (T)BaseGet(name);
        }
    
    
        public IEnumerable<T> Elements
        {
            get
            {
                for (int index = 0; index < this.Count; index++) yield return (T)BaseGet(index);
            }
        }
    
        /// <summary>
        /// Add an element to the collection
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(T element)
        {
            BaseAdd(element);
        }
    
    
    }
    
