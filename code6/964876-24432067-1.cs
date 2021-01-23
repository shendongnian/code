    [Table("Vendors")]
    public class Vendor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
