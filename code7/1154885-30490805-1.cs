    static class MathsExtensions
    {
        public static double GetVariance(this double[] values)
        {
            var avg = values.Average();
            return values.Select(value => (value - avg) * (value - avg)).Sum() / values.Count();
        }
    }
