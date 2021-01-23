    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace SOFAcrobatics
    {
        public static class Launcher
        {
            public static void Main ()
            {
                // 1 to 20 without duplicates
                List<Int32> ns = new List<Int32>();
                Random r = new Random();
                Int32 ph = 0;
                while (ns.Count < 20)
                {
                    while (ns.Contains (ph = r.Next(1, 21))) {}
                    ns.Add(ph);
                }
                // ns is now populated with random unique numbers (1 to 20)
            }
        }
    }
