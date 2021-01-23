    [Table("rapportAnomalie")]
    public partial class rapportAnomalie
     {
        [Key]
        public int code_rapport { get; set; }
        public DateTime date_rapport { get; set; }
        [Required]
        [StringLength(50)]
        public string etat { get; set; }
        
        public int code_agence { get; set; }
        [ForeignKey("code_agence")]
        public agence agence { get; set; }
     }
    }
