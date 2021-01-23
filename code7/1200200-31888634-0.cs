    [DataContract]
    public class EmailParms
    {
        [DataMember]
        [JsonProperty(DefaultValueHandling=DefaultValueHandling.IgnoreAndPopulate)]
        public virtual string EmailId { get; set; }
        [DataMember]
        [JsonProperty(DefaultValueHandling=DefaultValueHandling.IgnoreAndPopulate)]
        public virtual string emailId { get; set; }
    }
