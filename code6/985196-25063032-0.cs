    [DataContract]
    class shipment
    {
        [DataMember(Name="@id")]
        public string id { get; set; }
        [DataMember]
        public string consignee { get; set; }
    }
