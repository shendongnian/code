    class Bag
    {
        public int Id { get; set; }
        public ICollection<RandomThing> RandomThings { get; set; }
    }
    
    class RandomThing
    {
        public int Id { get; set; }
        public String Description{ get; set; }
        public Bag Bag { get; set; }
        public int BagId { get; set; }
    }
