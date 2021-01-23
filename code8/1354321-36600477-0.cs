    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CityPair = System.Tuple<string, string>; //just for short
    namespace cards
    {
        class Program
        {
            static void Main(string[] args)
            {
                var source = new[]
                {
                    Tuple.Create("London", "New-York"),
                    Tuple.Create("Sydney", "Moscow"),
                    Tuple.Create("New-York", "Sydney")
                };
                //convert to hash-map 
                var graphIncedence = 
                  new Dictionary<string, CityPair>(source
                        .ToDictionary(x => x.Item1, x=>x));
                //convert to inverted hash_map 
                var invertedGraph = 
                     new Dictionary<string, CityPair>(source
                        .ToDictionary(x => x.Item2, x => x));
                //find all nodes without input links
                var startNodes = graphIncedence
                    .Where((pair) => !graphIncedence.ContainsKey(pair.Value.Item2))
                    .Select(pair=> pair.Value).ToList();
                //for each start node build a path
                foreach (var start in startNodes) //remove it if only 1 start node
                {
                    Console.Write("Start node is: '{0}'", start.Item2);
                    //produce list where items just follow after startNode
                    for (var next = start.Item1; next != null;)
                    {
                        Console.Write("-> {0}", next);
                        CityPair result;
                        next = !invertedGraph.TryGetValue(next, out result) 
                               ? null : result.Item1;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
