    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            private static readonly int ITERATIONS = 5000000;
            private static readonly int RANDOM_MAX = 101;
    
            private static int GetCryptoRandom()
            {
                var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                byte[] bytes = new byte[4];
                rng.GetBytes(bytes);
                return bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3];
            }
    
            private static ThreadLocal<Random> m_rnd = new ThreadLocal<Random>(() => new Random(GetCryptoRandom()));
    
            private static Random _rnd
            {
                get
                {
                    return m_rnd.Value;
                }
            }
    
            static void Main(string[] args)
            {
                ConcurrentDictionary<int, int> dic = new ConcurrentDictionary<int, int>();
                Parallel.For(1, ITERATIONS, _ => dic.AddOrUpdate(_rnd.Next(1, RANDOM_MAX), 1, (k, v) => v + 1));
                foreach (var kv in dic)
                    Console.WriteLine("{0} -> {1:0.00}%", kv.Key, ((double)kv.Value / ITERATIONS) * 100);
    
            }
        }
    }
