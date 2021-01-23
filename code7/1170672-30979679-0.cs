    using System;
    using System.IO;
    using System.Collections.Generic;
    namespace StringSameStart
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                var files = Directory.GetFiles("/Users/ibrar", "*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Console.WriteLine("file : " + file);
                }
                Array.Sort(files);
                var first = files[0];
                var last = files[files.Length - 1];
                List<char> list = new List<char>();
                for (int ctr = 0; ctr < files[0].Length; ctr++)
                {
                    if (first[ctr] != last[ctr])
                    {
                        break;
                    }
                    Console.WriteLine("Same : " + first[ctr]);
                    list.Add(first[ctr]);
                }
                Console.WriteLine("Match : " + new string(list.ToArray()));
            }
        }
    }
