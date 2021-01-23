    class Bag
    {
        public int Id { get; set; }
        public virtual ICollection<RandomThing> RandomThings { get; set; }
    }
    
    class RandomThing
    {
        public int Id { get; set; }
        public String Description{ get; set; }
    
        public int BagId {get; set;}
        [ForeignKey("BagId")]
        Public Bag Bag {get; set;}
    }
