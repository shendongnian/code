    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MM
    {
        public static class BitScanner
        {
            static Int32 GetLSBPosition(UInt64 v)
            {
                UInt64 x = 1;
                for (var y = 0; y < 64; y++)
                {
                    if ((x & v) == x)
                    {
                        return y;
                    }
                    x = x << 1;
                }
                return 0;
            }
    
            static void Main(string[] args)
            {
                const int countR = 100000000;
    
                var clean = Stopwatch.StartNew();
    
                ulong sum = 0;
                for (ulong i = 0; i < countR; i++)
                {
                    sum += i;
                }
                clean.Stop();
    
                Console.Write(sum); // to not optimize
                sum = 0;
    
                var getLsbPositionWatch = Stopwatch.StartNew();
                for (int i = 0; i < countR; i++)
                {
                    sum += (ulong)GetLSBPosition((ulong)i);
                }
                getLsbPositionWatch.Stop();
    
                Console.Write(sum); // to not optimize
    
                Console.WriteLine("Clean: {0}", clean.ElapsedMilliseconds);
    
                Console.WriteLine("GetLSBPosition: {0}", getLsbPositionWatch.ElapsedMilliseconds);
    
                double zeSpeed =1000D * countR / (getLsbPositionWatch.ElapsedMilliseconds - clean.ElapsedMilliseconds);
                Console.WriteLine("GetLSBPosition Speed: {0}", zeSpeed);
    
                Console.ReadKey();
            }
        }
    }
