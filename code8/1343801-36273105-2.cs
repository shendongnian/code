    using System;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            //define your general apply function
            Func<double[], Func<double, double, double>, double, double> G = (vars, func, init) =>
            {
                double result = init;
                foreach (var t in vars)
                {
                    result = func(result,t);
                }
                
                return result;
            };
            //here is a product example    
            double test = G(new double[] { 1, 2, 3, 4 }, (prev, x) => prev * x, 1);
    		Console.WriteLine(test);
            //here is an addition example
    		test = G(new double[] { 1, 2, 3, 4 }, (prev, x) => prev + x, 0);
    		Console.WriteLine(test);            
        }	
    }
