    public class Player
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PlayerId { get; set; }
    
        public virtual ICollection<Aquarium> Aquariums { get; set; }
        public virtual ICollection<AquariumObject> AquariumObjects{ get; set; }
    }
    public class AquariumObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AquariumObjectId { get; set; }
        
        public int? AquariumId { get; set; }
        public virtual Aquarium { get; set; }
        public Guid PlayerId { get; set; }
        public virtual Player { get; set; }
    }
    public class Aquarium
    {
        [Key]
        [Column(Order = 1)]
        public int AquariumId { get; set; }
        public Guid PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<AquariumObject> AquariumObjects { get; set; }
    }
