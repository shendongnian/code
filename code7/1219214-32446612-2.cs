<!-- language: lang-css --
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
                Full full = new Full()
                {
                    FullId = "A",
                    Tapes = new List<string>() { "1", "2", "4" }
                };
                List<OptSet> optSet = new List<OptSet>() {
                    new OptSet() { SetId = "x", Tapes2 = new List<string>() {"1", "2", "3"}},
                    new OptSet() { SetId = "y", Tapes2 = new List<string>() {"1", "2", "4"}},
                    new OptSet() { SetId = "z", Tapes2 = new List<string>() {"1", "2", "3", "4"}}
                };
                List<OptSet> results = optSet.Where(x => full.Tapes.Where(y => !x.Tapes2.Contains(y)).Count() == 0).ToList();
            }
        }
        public class Full
        {
            public string FullId { get; set; }
            public List<string> Tapes { get; set; }
        }
        public class OptSet
        {
            public string SetId { get; set; }
            public List<string> Tapes2 { get; set; }
        }
    }
    ​
