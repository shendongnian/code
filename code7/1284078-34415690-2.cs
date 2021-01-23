    class Program
    {
    
        class Test
        {
            public decimal? Value { get; set; }
        }
    
        static void Main(string[] args)
        {
            var step2 = new Test[] { null };
    
            double indicatorValue = step2.Count() > 0 ? step2.Sum(iv => ((double?)iv.Value) ?? 0d) : 0d;
    
            Console.WriteLine(indicatorValue);
        }
    }
