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
                Full full = new Full();
                OptSet optSet = new OptSet();
                List<string> results = full.Tapes.Where(x => optSet.Tapes2.Contains(x)).ToList();
            }
        }
        public class Full
        {
            public string FullId {get; set;}
            public List<string> Tapes {get; set;}
        }
        public class OptSet
        {
            public string SetId {get; set;}
            public List<string> Tapes2 {get; set;}
        }
    }
    ​
