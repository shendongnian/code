    [DataContract]
    public class CResults
    {
        [DataMember(Order = 0)]
        public string studentname { get; set; }
        [DataMember(Order = 1)]
        public string studentid { get; set; }
        [DataMember(Order = 2)]
        public string telugu { get; set; }
        [DataMember(Order = 3)]
        public string hindi { get; set; }
        [DataMember(Order = 4)]
        public string english { get; set; }
        [DataMember(Order = 5)]
        public string mathematics { get; set; }
        [DataMember(Order = 6)]
        public string science { get; set; }
        [DataMember(Order = 7)]
        public string social { get; set; }
        [DataMember(Order = 8)]
        public string totalresult { get; set; }
    }
