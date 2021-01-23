    using System;
    using MathNet.Numerics.Statistics;
    class Test
    {
        static void Main()
        {
            double[] numbers = new double[] { 1, 2, 3, 4, 5 };
            double a = SortedArrayStatistics.Minimum(numbers);
            double b = SortedArrayStatistics.LowerQuartile(numbers);
            double c = SortedArrayStatistics.Median(numbers);
            double d = SortedArrayStatistics.UpperQuartile(numbers);
            double e = SortedArrayStatistics.Maximum(numbers);
    
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n", a,b,c,d,e);
        }
    }
