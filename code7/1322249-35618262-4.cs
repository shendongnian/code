    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("-120, denormal? " + IsDenormal((float)Math.Pow(2, -120)));
                Console.WriteLine("-126, denormal? " + IsDenormal((float)Math.Pow(2, -126)));
                Console.WriteLine("-127, denormal? " + IsDenormal((float)Math.Pow(2, -127)));
                Console.WriteLine("-149, denormal? " + IsDenormal((float)Math.Pow(2, -149)));
                Console.ReadKey();
            }
    
            public static bool IsDenormal(float f)
            {
                // when 0, the exponent will also be 0 and will break
                // the rest of this algorithm, so we should check for
                // this first
                if (f == 0f)
                {
                    return false;
                }
                // Get the bits
                byte[] buffer = BitConverter.GetBytes(f);
                int bits = BitConverter.ToInt32(buffer, 0);
                // extract the exponent, 8 bits in the upper registers,
                // above the 23 bit significand
                int exponent = (bits >> 23) & 0xff;
                // check and see if anything is there!
                return exponent == 0;
            }
        }
    }
