    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Machine
    {        /// <remarks/>
        public MachineAsset Asset { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MachineAsset
    {
        public string Product { get; set; }
        public uint OrderNumber { get; set; }
        public uint ServiceTag { get; set; }
        public System.DateTime ShipDate { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("Warranty", IsNullable = false)]
        public MachineAssetWarranty[] Warranties { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MachineAssetWarranty
    {
        public MachineAssetWarrantyService Service { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Services { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MachineAssetWarrantyService
    {
        public string ServiceDescription { get; set; }
        public string Provider { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Type { get; set; }
    }
