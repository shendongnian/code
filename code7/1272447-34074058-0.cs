    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace YourNameSpace
    {
	    [XmlRoot(ElementName="Item")]
    	public class Item
        {
	    	[XmlElement(ElementName="shipAddress")]
		    public string ShipAddress { get; set; }
    		[XmlElement(ElementName="shipMethod")]
	    	public string ShipMethod { get; set; }
		    [XmlElement(ElementName="rate")]
    		public string Rate { get; set; }
	    	[XmlElement(ElementName="custom")]
		    public Dictionary<string,int> Custom { get; set; }
    		[XmlElement(ElementName="special")]
    		public Dictionary<string,int>Special { get; set; }
	    }
	    [XmlRoot(ElementName="itemList")]
	    public class ItemList
        {
		    [XmlElement(ElementName="Item")]
		    public List<Item> Item { get; set; }
	    }
    }
