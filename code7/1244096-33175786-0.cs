    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2005/Atom", IsNullable = false)]
    public partial class feed
    {
        public feedTitle title { get; set; }
        public string id { get; set; }
        public System.DateTime updated { get; set; }
        public feedLink link { get; set; }
        public feedEntry entry { get; set; }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    public partial class feedTitle
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    public partial class feedLink
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rel { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string href { get; set; }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    public partial class feedEntry
    {
        public string id { get; set; }
        public feedEntryTitle title { get; set; }
        public System.DateTime published { get; set; }
        public System.DateTime updated { get; set; }
        public feedEntryContributor contributor { get; set; }
        public feedEntryContent content { get; set; }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    public partial class feedEntryTitle
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    public partial class feedEntryContributor
    {
        public string name { get; set; }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    public partial class feedEntryContent
    {
        public feedEntryContentEntry Entry { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    public partial class feedEntryContentEntry
    {
        public ushort EntryID { get; set; }
        public byte CategoryID { get; set; }
        public byte EventID { get; set; }
        public byte GroupID { get; set; }
        public byte ContactID { get; set; }
        public byte AddressTypeID { get; set; }
        public byte PinNumber { get; set; }
        public object Password { get; set; }
        public object PortalEmail { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public object NameTitle { get; set; }
        public string NamePreferred { get; set; }
        public string NameWeb { get; set; }
        public object NameOther { get; set; }
        public object NameInitials { get; set; }
        public object NameSharer { get; set; }
        public string GenderEnum { get; set; }
        public string Birth_GenderEnum { get; set; }
        public bool DirectoryFlagPrivacy { get; set; }
        public object Position { get; set; }
        public uint ID1 { get; set; }
        public string ID2 { get; set; }
        public object ID3 { get; set; }
        public byte ID4 { get; set; }
        public byte ID5 { get; set; }
        public bool PhoneProcessToAccount { get; set; }
        public byte PhoneChargeTypeID { get; set; }
        public byte PhoneDisableValue { get; set; }
        public byte PhoneRestrictValue { get; set; }
        public string PhoneControlEnum { get; set; }
        public string TaxExemptionEnum { get; set; }
        public bool Testing { get; set; }
        public uint timestamp { get; set; }
    }
