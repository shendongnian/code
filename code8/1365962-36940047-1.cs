    public class Things
    {
        public double WorstPrice { get; readonly set; }
        public double BestPrice = { get; readonly set; }
        // etc
        public Things(double worstPrice, double bestPrice) // etc
        {
            WorstPrice = worstPrice;
            BestPrice = bestPrice;
        }
    }
