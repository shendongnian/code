    [Table("Profile")]
    public class Profile
    {
        public Profile()
        {
        }
        [Column(Order = 1)]
        [Key]        
        public Guid ProfileID { get; set; }
        [JsonIgnore]
        public virtual ICollection<StudentLivingWith> StudentProfileMap { get; set; }
        [JsonIgnore]
        public virtual ICollection<StudentLivingWith> ParentProfileMap { get; set; }
    }
