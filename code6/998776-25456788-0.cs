    [XmlRootAttribute("items")]
    public class UpdateXML
    {
        private List<Item> _items;
    
    	[XmlElement("item")]
        public List<Item> Items
        {
            get { return this._items; }
            set { this._items = value; }
        }
    }
