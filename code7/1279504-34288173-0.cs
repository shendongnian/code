    public class ScoreData
    {
        [DataMember(Name="Client Experience")]
		public string ClientExperience { get; set; }
        
		[DataMember(Name="Stability & Ownership")]
		public string StabilityOwnership { get; set; }
        
		[DataMember(Name="Property ownership")]
		public string PropertyOwnership { get; set; }
        
		[DataMember(Name="Co-app/Guarantor")]
		public string CoAppGuarantor { get; set; }
        
		[DataMember(Name="proposed cost")]
		public string ProposedCost { get; set; }
    }
    public class Example
    {
        public string ProspectNo { get; set; }
        public string MakerId { get; set; }
        public string MkrDate { get; set; }
        public object TranID { get; set; }
        public ScoreData ScoreData { get; set; }
    }
