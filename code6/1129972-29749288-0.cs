    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        [ForeignKey("ContactId")]
        public User ContactUser { get; set; }
    }
