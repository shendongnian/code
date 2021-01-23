    public class Person
    {
        [Key]
        public int ID {get; set;}
    
        [InverseProperty("Friend1")]
        public virtual ICollection<Friendship> FShip1{ get; set; }
    
        [InverseProperty("Friend2")]
        public virtual ICollection<Friendship> FShip2{ get; set; }
    }
