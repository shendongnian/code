    public class Ninja
    {
        public int Id { get; set; }
    
        public virtual Ninja BestFriend { get; set; }
        public virtual Ninja Enemy { get; set; }
    
        [InverseProperty("BestFriend")]
        public virtual ICollection<Ninja> whoseBestFriend { get; set; }
        [InverseProperty("Enemy")]
        public virtual ICollection<Ninja> whoseEnemy { get; set; }
    }
