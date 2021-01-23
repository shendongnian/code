    class Farmer
    {
        public Farmer(int numberOfCows, int feedMultiplier)
        {
            this.FeedMultiplier = feedMultiplier;
            this.NumberOfCows = numberOfCows;
        }
        public int FeedMultiplier { get; private set; }
        public int NumberOfCows { get; set; }
        public int BagsOfFeed {
            get { return NumberOfCows * FeedMultiplier; }
        }
    }
