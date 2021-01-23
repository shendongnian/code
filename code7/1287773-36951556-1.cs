    [Table("StudentLivingWith")]
    public class StudentLivingWith
    {
        public StudentLivingWith()
        {
        }
        [Column(Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentLivingWithID { get; set; }
        [Column(Order = 2)]
        [ForeignKey("StudentProfileID")]
        public Guid StudentProfileID { get; set; }
        [Column(Order = 3)]
        [ForeignKey("ParentProfileID")]
        public Guid ParentProfileID { get; set; }
        [JsonIgnore]
        [InverseProperty("StudentProfileMap")]
        public virtual ICollection<Profile> StudentProfile { get; set; }
        [JsonIgnore]
        [InverseProperty("ParentProfileMap")]
        public virtual ICollection<Profile> ParentProfile { get; set; }
    }    
