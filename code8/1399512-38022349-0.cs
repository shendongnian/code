    [DataContract(Namespace = "JobTransactionTopic.Notification")]
    public class Notification
    {
        #region Public Properties
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int LoginId { get; set; }
        [DataMember]
        public string Title { get; set; }
        #endregion
    }
