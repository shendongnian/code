    public partial class County : Entity
    {
        public int CountyID { get; set; }
        public string CountyName { get; set; }
        public string UserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedUserID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual IList<Property> Properties { get; set; }
        public virtual DistrictOffice DistrictOffice { get; set; }
        public virtual IList<Recipient> Recipients { get; set; }
    }
