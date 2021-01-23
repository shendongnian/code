    [Table("M_SubSpecialization")]
        public partial class SubSpecialization : Entity
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public Int32 SuID { get; set; }
            public string SubCode { get; set; }
            public Int32 SID { get; set; }  // This is required in order to map between specialization and subspecialization
      
            [ForeignKey("SID")]
            public virtual Specialization Specialization { get; set; }
        }
    
