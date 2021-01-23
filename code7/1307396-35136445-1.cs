    [DataContract]
    public class EvtTypes
    {
        [DataMember(Name="cnt", Order=1)]
        public string EvtType { get; set; }
        [DataMember(Name="name", Order=2)]
        public int EvtCnt { get; set; }
    } 
