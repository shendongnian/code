    [DataContract]
    class JsonResponse
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public Result result { get; set; }
    }
    [DtaContract]
    class Result
    {
        [DataMember]
        public string studentStatus { get; set; }
        [DataMember]
        public List<Results> results { get; set; }
    }
    
    [DtaContract]
    class Results
    {
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public double creditAmount { get; set; }
        [DataMember]
        public int timeUnit { get; set; }
        [DataMember]
        public string mark { get; set; }
        [DataMember]
        public bool passed { get; set; }
        [DataMember]
        public string staffMemberName { get; set; }
        [DataMember]
        public List<Results> subResults { get; set; }
    }
