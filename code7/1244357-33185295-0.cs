    [DataContract]
    public class Item
    {
        [DataMember(Name = "view_count")]
        public int ViewCount { get; set; }
    
        [DataMember(Name = "answer_count")]
        public int AnswerCount { get; set; }
    
        [DataMember(Name = "score")]
        public int Score { get; set; }
    
        [IgnoreDataMember]
        public Date LastActivityDate { get; private set; }
        [DataMember(Name = "last_activity_date")]
        private long Date
        {
            set
            {
                LastActivityDate = value;
            }
            get
            {
                return LastActivityDate.ElapsedSeconds;
            }
        }
    }
