    public class MeritFunction<TCalcOutput> : IEnumerable<MeritFunctionLine<TCalcOutput>>
    {
        public List<MeritFunctionLine<TCalcOutput>> Lines { get; set; }
    
        public MeritFunction()
        {
            Lines = new List<MeritFunctionLine<TCalcOutput>>();
        }
    
        public void Add(Func<TCalcOutput, double> property, ComparisonTypes ComparisonType, double value)
        {
            Lines.Add(new MeritFunctionLine<CalculationOutput>
            {
                property = property,
                value = value,
                comparisonType = ComparisonType
            });
        }
    
        public double Calculate(TCalcOutput values)
        {
            double m = 0;
            foreach (var item in Lines)
            {
                m += Math.Abs(item.property(values) - item.value);
            }
            return m;
        }
        
        public IEnumerator<MeritFunctionLine<TCalcOutput>> GetEnumerator()
        {
            return List.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
