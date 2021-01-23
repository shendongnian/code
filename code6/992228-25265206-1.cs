    class Program
    {
        static void Main(string[] args)
        {
            MeritFunction<CalculationOutput> mf = new MeritFunction<CalculationOutput>();
            //Create an instance of the object for reference.
            var obj = new CalculationOutput();
            //Use Lambda to set the Property Expression on the Line, pointing at the Property we are interested in.
            mf.Lines.Add(new MeritFunctionLine() { PropertyExpression = () => obj.property1, value = 90, ComparisonType = ComparisonTypes.GreaterThan });
            mf.Lines.Add(new MeritFunctionLine() { PropertyExpression = () => obj.property3, value = 50, ComparisonType = ComparisonTypes.Equals });
            CalculationOutput c1 = new CalculationOutput() { property1 = 1, property2 = 20, property3 = 150, property4 = 500 };
            CalculationOutput c2 = new CalculationOutput() { property1 = 15, property2 = 32, property3 = 15, property4 = 45 };
            double value1 = mf.Calculate(c1);
            double value2 = mf.Calculate(c2);
            Console.WriteLine(value1);
            Console.WriteLine(value2);
        }
    }
    public class MeritFunctionLine
    {
        //Capture an expression representing the property we want.
        public Expression<Func<double>> PropertyExpression { get; set; }
        public double value { get; set; }
        public ComparisonTypes ComparisonType { get; set; }
    }
    public class MeritFunction<T>
    {
        public List<MeritFunctionLine> Lines { get; set; }
        public MeritFunction()
        {
            Lines = new List<MeritFunctionLine>();
        }
        public double Calculate(T values)
        {
            double m = 0;
            foreach (var item in Lines)
            {
                //Get the Value before calculating.
                double value = ExtractPropertyValue(item, values);
                m += Math.Abs(value - item.value);
            }
            return m;
        }
        /// <summary>
        /// Take the Provided Expression representing the property, and use it to extract the property value from the object we're interested in.
        /// </summary>
        private double ExtractPropertyValue(MeritFunctionLine line, T values)
        {
            var expression = line.PropertyExpression.Body as MemberExpression;
            var prop = expression.Member as PropertyInfo;
            double value = (double)prop.GetValue(values);
            return value;
        }
    }
    public class CalculationOutput
    {
        public double property1 { get; set; }
        public double property2 { get; set; }
        public double property3 { get; set; }
        public double property4 { get; set; }
    }
    public enum ComparisonTypes
    {
        GreaterThan,
        Equals
    }
