    public partial class T_TABLE
    {    
        [Key]
        public int ID { get; set; }
    
        [MaxLength(45)]
        public string NAME { get; set; }
    }
