    using System;
    using System.Collections.Generic;
    using System.Linq;
    static class Program {
        static void Main(string[] args) {
            List<string> selected = new List<string> { "A", "B", "B.1", "B.11", "C" };
            List<string> required = new List<string> { "B", "C" };
            var matching = from s in selected where required.Any(r => s.StartsWith(r)) select s;
            foreach (string m in matching) {
                Console.WriteLine(m);
            }
        }
    }
