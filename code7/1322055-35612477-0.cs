    public class FormReport : Entity
    {
        [Column("FormEntry_Id")]) // Map to the existing column name
        [ForeignKey("FormEntry")] // Associate with the navigation property 
        public Guid? FormEntryId { get; set; }
        public virtual FormEntry FormEntry { get; set; }
        //other props
    }
