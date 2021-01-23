    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Order=4)]
    [System.Xml.Serialization.XmlArrayItemAttribute("ItineraryItem", IsNullable=false)]
    [System.Xml.Serialization.XmlArrayItemAttribute(Namespace  = "http://api.codegen.net/ota/tbx")]
    public PkgItineraryItemType[] ItineraryItems {
        get {
            return this.itineraryItemsField;
        }
        set {
            this.itineraryItemsField = value;
            this.RaisePropertyChanged("ItineraryItems");
        }
    }
