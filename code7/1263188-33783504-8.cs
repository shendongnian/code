    public class CostsPerWeight
    {
        class CostPerWeight
        {
            public int Low;
            public int High;
            public double Cost;
        }
        readonly List<CostPerWeight> costs = new List<CostPerWeight>();
        double min = double.MaxValue;
        double max = double.MinValue;
        double costForMin;
        public CostsPerWeight Add(int low, int high, double cost)
        {
            if (low > high)
                throw new ArgumentException(nameof(low) + " must be less than " + nameof(high));
            if (cost < 0)
                throw new ArgumentOutOfRangeException(nameof(cost), "cost must be greater than zero");
            costs.Add(new CostPerWeight { Low = low, High = high, Cost = cost } );
            if (low < min)
            {
                min = low;
                costForMin = cost;
            }
            if (high > max)
                max = high;
            return this;
        }
        public double Cost(int weight)
        {
            if (weight < min)
                return costForMin;
            if (weight > max)
                throw new InvalidOperationException($"Weight {weight} is out of range: Must be <= {max}");
            return costs.First(x => x.Low <= weight && weight <= x.High).Cost;
        }
    }
