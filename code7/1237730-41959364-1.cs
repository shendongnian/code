     [Table("M_Specialization")]
        public partial class Specialization : Entity
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int SID { get; set; }
            public string SCode { get; set; }
            public string Description { get; set; }
            public virtual ICollection<SubSpecialization> SubSpecializationDetails { get; set; }
    }
    
