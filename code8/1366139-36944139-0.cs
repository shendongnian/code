    public class Body
    {
        public int Id { get; set; }
        public Hand hand { get; set; }
        public Foot foot { get; set; }
        public Head head { get; set; }
    
        public class Hand
        {
            public List<Fingers> fingers { get; set; }
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
    }
