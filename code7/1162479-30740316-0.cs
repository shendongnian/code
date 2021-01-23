    public class Toy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int KidID { get; set; }
        [ForeignKey("KidID")]
        [InverseProperty("Toys")]
        public virtual Kid Kid { get; set; }
    }
    public class Kid
    {
        public string Name { get; set; }
        [InverseProperty("Kid")]
        public virtual ICollection<Toy> Toys { get; set; }
    }
