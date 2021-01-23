    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                var a = letterCounter("The quick brown fox jumps over the lazy dog");
                Console.ReadKey();
            }
            private const string charsToBeCounted = "abcdefghikjlmnopqrstuvwxyz"; // ABCDEFGHIKJLMNOPQRSTUVWXYZ capital letters not needed converting the string to lowercase
            public static Dictionary<char, int> letterCounter(string word)
            {
                var ret = new Dictionary<char, int>();
                word = word.ToLower();
                foreach (char ch in word)
                {
                    if (charsToBeCounted.Contains(ch))
                    {
                        if (ret.ContainsKey(ch))
                            ret[ch]++;
                        else
                            ret[ch] = 1;
                    }
                }
                return ret;
            }
        }
    }
