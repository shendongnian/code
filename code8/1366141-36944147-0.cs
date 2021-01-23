    public class Hand
    {
        public List<Fingers> fingers { get; set; }
    }
    public class Body
    {
        public int Id { get; set; }    
        public Hand Hand {set;get;}
        public Foot Foot { set;get;}
        public Head Head { set;get;}
    }
        public class Foot
        {
            public List<Toes> toes { get; set; }
        }
    
        public class Head
        {
            public Nose nose {get; set;}
            public List<Ears> ears { get; set; }
            public List<Eyes> eyes { get; set; }
        }
