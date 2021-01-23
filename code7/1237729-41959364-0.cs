    I was having similar issue.
    
    Your above code seems to be correct , I think you have missed to specify the mapping in dbcontext.cs class which resulted in below error 
    -------------- error ---------------
    "The object could not be added to the EntityCollection or EntityReference. An object that is attached to an ObjectContext cannot be added to an EntityCollection or EntityReference that is not associated with a source object."
    ------------------------------------
    
    
    I hope my below example could help you.
    
    -----------------------------------------------------------------
     Specialization (Parent Entity Class)
    -----------------------------------------------------------------
    
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
    
    -----------------------------------------------------------------
    Sub specialization (Child Entity Class)
    -----------------------------------------------------------------
    
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
    
    -----------------------------------------------------------------
    dbcontext.cs: 
    -----------------------------------------------------------------
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      	modelBuilder.Entity<SubSpecialization>().HasRequired(c => c.Specialization)
          .WithMany(s => s.SubSpecializationDetails)
          .HasForeignKey(c => c.SID);
    }
