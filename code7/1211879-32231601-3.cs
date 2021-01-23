    public class Councillor
    {
        [Key]
        public int CouncillorId { get; set; }
        public string Name { get; set; }
        // Junction Table Navigation Property
        [ForeignKey("CouncillorId")]
        public virtual ICollection<CouncillorCommittee> CouncilorCommittees { get; set; }
    }
    
    public class Committee
    {
        [Key]
        public int CommitteeId { get; set; }
        public string Name { get; set; }
        public int ChairmanId { get; set; }
        public int ViceChairmanId { get; set; }
        [ForeignKey("ChairmanId")]
        public virtual Councillor Chairman { get; set; }
        [ForeignKey("ViceChairmanId")]
        public virtual Councillor ViceChairman { get; set; }
        // Junction Table Navigation Property
        [ForeignKey("CommitteeId")]
        public virtual ICollection<CouncillorCommittee> CouncilorCommittees { get; set; }
    }
    // Represents the joining table
    public class CouncillorCommittee
    {
        [Key]
        public int CouncillorCommitteeId { get; set; }
        public int CouncillorId { get; set; }
        public int CommitteeId { get; set; }
        [ForeignKey("CouncillorId")]
        public virtual Councillor Councillor { get; set; }
        [ForeignKey("CommitteeId")]
        public virtual Committee Committee { get; set; }
    }
