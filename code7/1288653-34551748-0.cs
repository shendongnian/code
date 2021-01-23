    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        [DebuggerDisplay("{Name} {Radial} {Area}")]
        public class TransformerStation
        {
            public string Name { get; set; }
            public string Radial { get; set; }
            public string Area { get; set; }
            public TransformerStation(string name, string radial, string area)
            {
                Name = name;
                Radial = radial;
                Area = area;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                CSVToDictionary();
            }
            private static void CSVToDictionary()
            {
                var dictionary = new Dictionary<string, TransformerStation>();
                // your csv
                string[] lines = new string[] {
                "N765; TANGEN; TANGEN L98",
                "R2351; SPIKKESTAD; SPIKKESTAD K88",
                "S622; KRÅKSTAD; KRÅKSTAD L812",
                "S1318; KRÅKSTAD; KRÅKSTAD L812"};
                foreach (var line in lines)
                {
                    var data = line.Split(';');
                    dictionary.Add(data[0], new TransformerStation(data[0].Trim(), data[1].Trim(), data[2].Trim()));
                }
                var find = "KRÅKSTAD L812";
                var search = dictionary.Values.Where(v => v.Area == find);
                foreach (var found in search)
                {
                    Console.WriteLine($"Matches: {found.Name} {found.Radial} {found.Area}");
                }
            }
        }
    }
