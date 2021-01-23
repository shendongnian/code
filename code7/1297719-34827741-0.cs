    public partial class PropertyListing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ID")]
        public int ID { get; set; }
        public string StreetAddress { get; set; }
        //the column that links with PropertyAvaibility table PK
        public byte? Availability { get; set; }
    
        public bool Status { get; set; }
    
        public virtual PropertyAvailability PropertyAvailability { get; set; }
    }
