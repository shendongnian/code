    [Table("ContactLink")] // TPT inheritance
    class ContactLink
    {
        public Guid Contact_Link_ID { get; set; } //pk
        public Guid Tenant_ID { get; set; } //fk
        public Guid Contact_ID { get; set; } //fk
    }
    [Table("ContactLinkCustomer")] // TPT inheritance
    internal class ContactLinkCustomer : ContactLink
    {
        // Dummy property to trick EF into creating it as a column for sharding purposes
        // Callers should just directly use the base Tenant_ID property
        // It would be nice if we could set this to be public/protected, but then EF
        // won't create it as a column. Maybe there is a workaround for this?
        [Column("Tenant_ID")]
        public Guid Tenant_ID_ContactLinkCustomer
        {
            get { return base.Tenant_ID; }
            set { base.Tenant_ID = value; }
        }
        public Guid Contact_Link_ID { get; set; } //fk
        public Guid Customer_ID { get; set; } //fk
    }
