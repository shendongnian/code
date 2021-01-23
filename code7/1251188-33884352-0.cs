    [MessageContract(IsWrapped=false)]
    [DataContract(Namespace = "http://www.example.org/fmw/xsd/hdr/v1")
    public partial class getAllElementsResponse 
    {
        [DataMember]
        [MessageHeader(Namespace="http://www.example.org/fmw/xsd/hdr/v1")]
        public ElementRetrieval.header header;
        [DataMember]
        [MessageBodyMember(Name="getAllElementsResponse", Namespace="http://www.example.org/mri/xsd/mer/v1", Order=0)]
        public ElementRetrieval.MultipleMeObjectsResponseType getAllElementsResponse1;
    }
