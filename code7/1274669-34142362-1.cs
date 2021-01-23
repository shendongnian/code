    public class Level
    {
        XElement self;
        public int LevelNum { get; set; }
        public string LevelName { get; set; }
        public int MaxBubbles { get; set; }
        public int MaxVisibleBubbles { get; set; }
        public int StartingPointValue { get; set; }
        public int MaxLevelTime { get; set; }
        public int LevelPassScore { get; set; }
        public int TapsToPopStandard { get; set; }
        public int InitialVisibleBubbles { get; set; }
        public string LevelDescription { get; set; }
        public bool SeqLinear { get; set; }
        public bool SeqEven { get; set; }
        public bool SeqOdd { get; set; }
        public bool SeqTriangular { get; set; }
        public bool SeqSquare { get; set; }
        public bool SeqLazy { get; set; }
        public bool SeqFibonacci { get; set; }
        public bool SeqPrime { get; set; }
        public bool SeqDouble { get; set; }
        public bool SeqTriple { get; set; }
        public bool SeqPi { get; set; }
        public bool SeqRecaman { get; set; }
    
        public IList<bool> Flags { the code from above here }
    
        public Level (XElement e)
        {
            self = e;
        }
    }
