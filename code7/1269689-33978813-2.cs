    using System;
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
				//                                                                                      1
                ulong a = Convert.ToUInt64("0000000000000000000000000000000000000000000000000000000000001101", 2);
                ulong b = Convert.ToUInt64("1110010101100101011001010110110101100101011001010110010101100101", 2);
                Console.WriteLine(dendrite(a, 4, b));
            }
            private static float dendrite(ulong mask, int len, ulong input)
            {
                return 1 - getBitCount(mask ^ (input & (ulong.MaxValue >> (64 - len)))) / (float)len;            
            }
            private static ulong getBitCount(ulong bits)
            {
                bits = bits - ((bits >> 1) & 0x5555555555555555UL);
                bits = (bits & 0x3333333333333333UL) + ((bits >> 2) & 0x3333333333333333UL);
                return unchecked(((bits + (bits >> 4)) & 0xF0F0F0F0F0F0F0FUL) * 0x101010101010101UL) >> 56;
            }
        }
    }
