    [Table("Adress")]
    public partial class Adress
    {
        public int Id { get; set; }
    
        [Column("Adress")]
        [StringLength(255)]
        public string Adress1 { get; set; }
    
        [StringLength(50)]
        public string Town { get; set; }
    }
