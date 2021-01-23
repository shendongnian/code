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
            public class letter
            {
                public int count;
                public string stringValue;
            }
            private const string charsToBeCounted = "abcdefghikjlmnopqrstuvwxyz"; // ABCDEFGHIKJLMNOPQRSTUVWXYZ capital letters not needed converting the string to lowercase
            public static Dictionary<char, letter> letterCounter(string word)
            {
                var ret = new Dictionary<char, letter>();
                word = word.ToLower();
                foreach (char ch in word)
                {
                    if (charsToBeCounted.Contains(ch))
                    {
                        letter l = null;
                        if (ret.ContainsKey(ch))
                            l = ret[ch];
                        else
                        {
                            l = new letter();
                            ret.Add(ch, l);
                        }
                        l.count++;
                        l.stringValue = "Any value you want";
                    }
                }
                return ret;
            }
        }
    }
