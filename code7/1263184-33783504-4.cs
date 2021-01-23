    public sealed class CostsPerWeight
    {
        class CostPerWeight
        {
            public int Low;
            public int High;
            public double Cost;
        }
        readonly List<CostPerWeight> costs = new List<CostPerWeight>();
        public CostsPerWeight Add(int low, int high, double result)
        {
            // Error handling omitted for brevity. 
            // Real code should check that low < high and that ranges do not overlap.
            costs.Add(new CostPerWeight { Low = low, High = high, Cost = result } );
            return this;
        }
        public double Cost(int weight)
        {
            // This throws if the weight isn't in the list.
            // If that's not what you want, you'd have to add extra error handling here.
            return costs.First(x => x.Low <= weight && weight <= x.High).Cost;
        }
    }
