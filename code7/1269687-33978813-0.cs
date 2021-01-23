    using System;
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                int a = Convert.ToInt32("0001101", 2);
                int b = Convert.ToInt32("1100101", 2);
                Console.WriteLine(dendrite(a, 4, b));
            }
            private static float dendrite(int mask, int len, int input)
            {
                return  1 - getBitCount(mask ^ (input & (int.MaxValue >> 32 - len))) / (float)len;            
            }
            private static int getBitCount(int bits)
            {
                bits = bits - ((bits >> 1) & 0x55555555);
                bits = (bits & 0x33333333) + ((bits >> 2) & 0x33333333);
                return ((bits + (bits >> 4) & 0xf0f0f0f) * 0x1010101) >> 24;
            }
        }
    }
