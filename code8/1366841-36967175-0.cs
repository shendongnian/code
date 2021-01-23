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
                List<Something> somethings = new List<Something>() {
                    new Something() { tab = 1},
                    new Something() { tab = 2},
                    new Something() { tab = 3},
                    new Something() { tab = 4},
                    new Something() { tab = 5},
                    new Something() { tab = 6},
                    new Something() { tab = 7},
                    new Something() { tab = 8},
                    new Something() { tab = 9}
                };
                var result = somethings.Take(3).Select((x, i) => somethings.Where((y, ii) => (ii % 3) == i).Select(z => z.tab).ToArray()).ToArray();
            }
        }
        public class Something
        {
            public int tab { get; set; }
        }
    }
