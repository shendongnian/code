    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class Solution
    {
        struct Counter
        {
            public int c1;
            public int c2;
        }
    
        static void Main(String[] args)
        {
            int T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; ++t)
            {
                string str = Console.ReadLine();
                if (str.Length % 2 == 1)
                {
                    Console.WriteLine(-1);
                    continue;
                }
                int n = str.Length / 2;
                // determine how many replacements s1 needs to be an anagram of s2
                string s1 = str.Substring(0, n);
                string s2 = str.Substring(n, n);
                Counter[] counter = new Counter[26];
                int ascii_a = (int)'a';
                for (int i = 0; i < n; ++i)
                {
                    counter[(int)s1[i] - ascii_a].c1 += 1;
                    counter[(int)s2[i] - ascii_a].c2 += 1;
                }
                int count = counter.Select((pair => Math.Abs(pair.c1 - pair.c2))).Sum();
                Console.WriteLine(count);
            }
        }
    }
