    [DataContract]
    internal class APIError
    {
        [DataMember (Name = "status")]
        public int StatusCode { get; set; }
        [DataMember (Name = "code")]
        public int ErrorCode { get; set; }
    }
