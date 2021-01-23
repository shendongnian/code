     [DataContract]
    public class MeetingDetailsForDeserializing
    {
        [DataMember(Order = 0)]
        public string MeetingNumber { get; set; }
        [DataMember(Order = 1)]
        public string PresiderEmailAddress { get; set; }
        [DataMember(Order = 2)]
        public string MeetingName { get; set; }
        [DataMember(Order = 3)]
        public string MeetingDescription { get; set; }
        [DataMember(Order = 4)]
        public DateTime MeetingDate { get; set; }
        [DataMember(Order = 5)]
        public string MeetingVenue { get; set; }
        [DataMember(Order = 6)]
        public string TimeStarted { get; set; }
        [DataMember(Order = 7)]
        public string TimeEnded { get; set; }
        [DataMember(Order = 8)]
        public string CompletionRate { get; set; }
        [DataMember(Order = 9)]
        public string Remarks { get; set; }
    }
  
