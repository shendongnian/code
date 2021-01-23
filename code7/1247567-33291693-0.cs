    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                GraphEdge graphEdge = new GraphEdge();
                var edges = graphEdge.dataset.Select(e => new GraphEdge()
                {
                    Source = e.SourceMachine.Trim(),
                    Target = e.TargetMachine.Trim(),
                    Weight = e.Connection
                }).ToList();
     
            }
        }
        public class GraphEdge
        {
            public string Source { get; set; }
            public string Target { get; set; }
            public int Weight { get; set; }
     
            public IQueryable<SeedTest> dataset = builder.GetAllSeedTest();
            public GraphEdge()
            {
            }
            public GraphEdge(string s, string t, int w)
            {
                Source = s;
                Target = t;
                Weight = w;
            }
            public partial class SeedTest
            {
            public string SourceMachine { get; set; }
            public string TargetMachine { get; set; }
            public int Connection { get; set; }
            public int ID { get; set; }
            }
        }
    }​
