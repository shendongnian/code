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
                Node father = new Node()
                {
                    name = "FATHER", points = 200, type = 2, children = new List<Node>(){
                        new Node() { 
                            name = "CHILD01", points = 120, type = 3, children = new List<Node>(){
                                new Node(){ 
                                    name = "CHILD04", points = 300, type = 3, children = new List<Node>(){
                                           new Node(){ name = "CHILD08", points = 220, type = 3, children = null},
                                           new Node(){ name = "CHILD09", points = 65, type = 1, children = null}
                                    }
                                },
                                new Node(){ name = "CHILD05", points = 15, type = 9, children = null}
                            }
                        },
                        new Node() { name = "CHILD02", points = 10, type = 1, children = null},
                        new Node(){ 
                            name = "CHILD03", points = 80, type = 2, children = new List<Node>(){
                                new Node(){
                                    name = "CHILD06", points = 25, type = 2, children = new List<Node>(){
                                        new Node(){ name = "CHILD10", points = 110, type = 7, children = null},
                                        new Node(){ name = "CHILD11", points = 195, type = 3, children = null}
                                    }
                                },
                                new Node(){ name = "CHILD07", points = 50, type = 7, children = null}
                            }
                        }
                    }
                };
                Count results = father.GetTotals(0);
                foreach (Count result in Node.results)
                {
                    Console.WriteLine("{0} Name = {1}, Points = {2}, Types = {3}",
                        string.Join("", Enumerable.Repeat("    ", result.level)),
                        result.name,
                        result.points,
                        string.Join(",", result.types.OrderBy(x => x.Key).Select(x => x.Key.ToString() + ":" + x.Value.ToString()).ToArray())
                        );
                }
            }
        }
        public class Count
        {
            public string name;
            public int level { get; set; }
            public int points { get; set; }
            public Dictionary<int, int> types { get; set; }
        }
        public class Node
        {
            public string name { get; set; }
            public int points { get; set; }
            public int type { get; set; }
            public List<Node> children { get; set; }
            public static List<Count> results = new List<Count>();
            public Count GetTotals(int level)
            {
                Count result = new Count();
                result.name = name;
                result.level = level;
                result.points = points;
                result.types = new Dictionary<int, int>();
                result.types.Add(type, 1);
                if (children != null)
                {
                    for (int childCount = children.Count - 1; childCount >= 0; childCount--)
                    {
                        Node child = children[childCount];
                        Count childResutls = child.GetTotals(level + 1);
                        result.points += childResutls.points;
                        foreach (int key in childResutls.types.Keys)
                        {
                            if (result.types.ContainsKey(key))
                            {
                                result.types[key] += childResutls.types[key];
                            }
                            else
                            {
                                result.types.Add(key, childResutls.types[key]);
                            }
                        }
                    }
                }
                Node.results.Insert(0, result);
                return result;
            }
        }
    }
    ​
