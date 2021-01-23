    using System;
    
    namespace SO30558357
    {
        class Program
        {
            static void XorArray(byte[] a, byte[] b)
            {
                for (int p = 0; p< 64; p++)
                    a[p] ^= b[p];
            }
    
            static void Main(string[] args)
            {
                byte[] a = new byte[64];
                byte[] b = new byte[64];
                Random r = new Random();
    
                r.NextBytes(a);
                r.NextBytes(b);
    
                XorArray(a, b);
                Console.ReadLine();  // when the program stops here
                                     // use Debug -> Attach to process
            }
        }
    }
