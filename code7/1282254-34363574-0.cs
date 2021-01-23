    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary < string, Tuple < HashSet < string >, HashSet < string>>> dict = new Dictionary<string,Tuple<HashSet<string>,HashSet<string>>>() {
                    { "A", new Tuple<HashSet<string>, HashSet<string>>( new HashSet<string>() {"Z", "B", "C", "D", "E"}, new HashSet<string>() { "movie0",  "movie1", "movie2", "movie7"})},
                    { "B", new Tuple<HashSet<string>, HashSet<string>>( new HashSet<string>() {"A", "C", "D", "E"}, new HashSet<string>() { "movie1",  "movie2", "movie7"})},
                    { "C", new Tuple<HashSet<string>, HashSet<string>>( new HashSet<string>() {"A", "B", "D"}, new HashSet<string>() { "movie1",  "movie7"})}
                };
                int mathces = Matches(dict["A"].Item2, dict["B"].Item2);
            }
            static int Matches(HashSet<string> hash1, HashSet<string> hash2)
            {
                return hash1.Where(x => hash2.Contains(x)).Count();
            }
        }
    }
    ​
