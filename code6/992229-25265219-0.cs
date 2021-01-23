    public class MeritFunctionLine<TCalcOutput>
    {
        public Func<TCalcOutput, double> property { get; set; }
        public double value { get; set; }
        public ComparisonTypes ComparisonType { get; set; }
    }
    public class MeritFunction<TCalcOutput>
    {
        public List<MeritFunctionLine<TCalcOutput>> Lines { get; set; }
        public double Calculate(TCalcOutput values)
        {
            double m = 0;
            foreach (var item in Lines)
            {
                m += Math.Abs(item.property(values) - item.value);
            }
            return m;
        }
    }
