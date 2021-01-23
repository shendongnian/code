    using System;
    
    class Test
    {
    	static void Main()
        {
            double x = Convert(24);
            Console.WriteLine(DoubleConverter.ToExactString(x));
        }
        
        static double Convert(int mpg)
        {
            return Math.Round((double) mpg / ((double) 36 / 12.74), 2);
        }
    }
