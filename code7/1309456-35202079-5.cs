    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    namespace TestEqual
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random rnd = new Random();
                List<float> numbers = new List<float>();
                for(int buc = 0; buc < 1000; buc++)
                    numbers.Add((float)rnd.NextDouble());
                var distinct = numbers.OrderBy(d => d).Distinct(new FComparer()).OrderBy(d => d).ToArray();
                Console.WriteLine(float.Epsilon);
                Console.WriteLine("Valores distintos: ");
            
                foreach (var f in distinct)
                    Console.WriteLine(f);
                foreach (var f in distinct)
                {
                    for (int buc = 0; buc < distinct.Length; buc++)
                        if (Math.Abs(f - distinct[buc]) < 0.001f && f != distinct[buc])
                            Console.WriteLine("Duplicate");
                
                }
                Console.ReadKey();
            }
            public class FComparer : IEqualityComparer<float>
            {
                public bool Equals(float x, float y)
                {
                    var dif = Math.Abs(x - y);
                    if ((x == 0 || y == 0) && dif < 0.001f)
                        return true;
                    if (Math.Sign(x) != Math.Sign(y))
                        return false;
                    return dif < 0.001f;
                }
                public int GetHashCode(float obj)
                {
                    //This is the key, if GetHashCode is different then Equals is not called
                    return 0;
                }
            }
        }
    }
