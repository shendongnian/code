    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("-120, subnormal? " + IsSubnormal((float)Math.Pow(2, -120)));
                Console.WriteLine("-126, subnormal? " + IsSubnormal((float)Math.Pow(2, -126)));
                Console.WriteLine("-127, subnormal? " + IsSubnormal((float)Math.Pow(2, -127)));
                Console.WriteLine("-149, subnormal? " + IsSubnormal((float)Math.Pow(2, -149)));
                Console.ReadKey();
            }
    
            public static bool IsSubnormal(float f)
            {
                // Get the bits
                byte[] buffer = BitConverter.GetBytes(f);
                int bits = BitConverter.ToInt32(buffer, 0);
                // extract the exponent, 8 bits in the upper registers, above the 23 bit significand
                int exponent = (bits >> 23) & 0xff;
                // check and see if anything is there!
                return exponent == 0;
            }
        }
    }
