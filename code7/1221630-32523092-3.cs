    public class Team
    {
      
        public int CatId { get; set; }
       
        public int DogId { get; set; }
      
        public Guid PigId { get; set; }
        public virtual Cat Cat { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual Pig Pig { get; set; }
    }
