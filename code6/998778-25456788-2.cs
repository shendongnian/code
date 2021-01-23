    [XmlRootAttribute("root")]
    public class UpdateXML
    {    
        private List<Item> _items;
    
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<Item> Items
        {
            get { return this._items; }
            set { this._items = value; }
        }
    }
