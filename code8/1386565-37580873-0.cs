    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ver = new List<Version>();
                ver.Add(new Version("3.5"));
                ver.Add(new Version("3.15"));
                ver.Add(new Version("3.10"));
                ver.Add(new Version("3.1"));
                ver.Sort();
                ver.Reverse();
            }
        }
    }
