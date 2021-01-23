    using System;
    using System.Collections.Generic;
    
    namespace FractionalKnapsackcsharp
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                int n = 0;
                double capacity;
                string n1 = Console.ReadLine();
                n = Convert.ToInt32(n1.Split(' ')[0]);
                capacity = Convert.ToDouble(n1.Split(' ')[1]);
    
                double[] values = new double[n];
                double[] weights = new double[n];
                for (int i = 0; i < n; i++)
                {
                    var answer = Console.ReadLine();
                    values[i] = Convert.ToDouble(answer.Split(' ')[0]);
                    weights[i] = Convert.ToDouble(answer.Split(' ')[1]);
                }
    
                double value = get_optimal_value(n, capacity, values, weights);
                Console.WriteLine(Math.Round(value, 4));
            }
    
            public static double get_optimal_value(int n, double capacity, double[] values, double[] weights)
            {
                double value = 0.0;
    
                Array.Sort(values, weights, Comparer<double>.Create((x, y) => y.CompareTo(x)));
    
                double[] ratio = new double[n];
    
                for (int i = 0; i < n; ++i)
                {
                    ratio[i] = values[i] / weights[i];
                }
    
                Array.Sort(ratio, weights, Comparer<double>.Create((x, y) => y.CompareTo(x)));
                //Array.Sort(ratio, weights, Comparer<double>.Create((x, y) => x.CompareTo(y)));
    
                //double[] A = new double[n];
                for (int i = 0; i < n; i++)
                {
                    if (capacity == 0) return value;
    
                    double a = weights[i] < capacity ? weights[i] : capacity;
                    //value = value + a * (values[i] / weights[i]);
                    value = value + a * ratio[i];
                    weights[i] = weights[i] - a;
                    //A[i] = A[i] + a;
                    capacity = capacity - a;
                }
                return value;
            }
        }
    }
