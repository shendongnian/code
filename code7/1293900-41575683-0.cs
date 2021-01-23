    public class Customer
    {
        [Column(Order = 10)]
        public int Id { get; set; }
        [Column(Order = 20)]
        public string Name { get; set; }
        [Column(Order = 30)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Column(Order = 40)]
        public string CreatedBy { get; set; }
        [Column(Order = 50)]
        public DateTime? ModifiedDate { get; set; }
        [Column(Order = 60)]
        public string ModifiedBy { get; set; }
        // Navigation properties
        public ICollection<Contact> Contacts { get; set; }
    } 
