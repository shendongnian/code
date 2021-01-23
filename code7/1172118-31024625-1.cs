    public class Person
    {
        [Key]
        [ForeignKey("Profil")]
        public Guid ProfilId { get; set; }
    
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
    
        public virtual Profil Profil { get; set; }
    }
