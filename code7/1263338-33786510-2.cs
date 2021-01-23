    [DataContract]
    [XmlRoot("order")]
    public class Order
    {
        [DataMember(Name = "consignments")]
        [XmlArray("consignments")]
        [XmlArrayItem("consignment")]
        public Consignment[] Consignments { get; set; }
    }
    [DataContract]
    public class Consignment
    {
        [DataMember(Name = "conh_id")]
        [XmlElement("conh_id")]
        public string ConsignmentHeaderId { get; set; }
        [DataMember(Name = "conh_status")]
        [XmlElement("conh_status")]
        public string ConsignmentHeaderStatus { get; set; }
        [DataMember(Name = "consignmententries")]
        [XmlArray("consignmententries")]
        [XmlArrayItem("consignmententry")]
        public ConsignmentEntry[] ConsignmentEntries { get; set; }
    }
