    [DataContract]
    public class PidDTO : BaseEntityDTO
    {
        [DataMember]
        public string PidId { get; set; }
        [DataMember]
        public VidDTO Vid { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual bool IsFromUser { get; set; }
    }
    [DataContract]
    public class VidDTO : BaseEntityDTO
    {
        [DataMember]
        public virtual string VidId { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual bool IsFromUser { get; set; }
    }
