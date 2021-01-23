    namespace MathNet.Numerics.Statistics
    {
        using System;
        using System.Collections.Generic;
        using Properties;
    
        /// <summary>
        /// A class with correlation measures between two datasets.
        /// </summary>
        public static class Correlation
        {
            /// <summary>
            /// Computes the Pearson product-moment correlation coefficient.
            /// </summary>
            /// <param name="dataA">Sample data A.</param>
            /// <param name="dataB">Sample data B.</param>
            /// <returns>The Pearson product-moment correlation coefficient.</returns>
            public static double Pearson(IEnumerable<double> dataA, IEnumerable<double> dataB)
            {
                int n = 0;
                double r = 0.0;
                double meanA = dataA.Mean();
                double meanB = dataB.Mean();
                double sdevA = dataA.StandardDeviation();
                double sdevB = dataB.StandardDeviation();
    
                IEnumerator<double> ieA = dataA.GetEnumerator();
                IEnumerator<double> ieB = dataB.GetEnumerator();
    
                while (ieA.MoveNext())
                {
                    if (ieB.MoveNext() == false)
                    {
                        throw new ArgumentOutOfRangeException("Datasets dataA and dataB need to have the same length.");
                    }
    
                    n++;
                    r += (ieA.Current - meanA) * (ieB.Current - meanB) / (sdevA * sdevB);
                }
                if (ieB.MoveNext() == true)
                {
                    throw new ArgumentOutOfRangeException("Datasets dataA and dataB need to have the same length.");
                }
    
                return r / (n - 1);
            }
        }
    }
    Math.NET Numerics works very well with C# and related .Net languages. When using Visual Studio or another IDE with built-in NuGet support, you can get started quickly by adding a reference to the MathNet.Numerics NuGet package. Alternatively you can grab that package with the command line tool with nuget.exe install MathNet.Numerics -Pre or simply download the Zip package.
