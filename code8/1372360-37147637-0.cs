    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace GraphModelTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                TestA();
                TestB();
                TestC();
            }
    
            private static void TestC()
            {
                //A <-> B
                //|     |
                //D <-> C
                Node a = new Node("a");
                Node b = new Node("b");
                Node c = new Node("c");
                Node d = new Node("d");
                Edge ab = a.ConnectTo(b);
                Edge bc = b.ConnectTo(c);
                Edge cd = c.ConnectTo(d);
                Edge da = d.ConnectTo(a);
                Graph g = new Graph();
                g.Nodes.Add(a);
                g.Nodes.Add(b);
                g.Nodes.Add(c);
                g.Nodes.Add(d);
                g.Edges.Add(ab);
                g.Edges.Add(bc);
                g.Edges.Add(cd);
                g.Edges.Add(da);
                Console.WriteLine(g.ToString());
    
                Console.WriteLine("Neighbours of B");
                foreach (Node n in b.GetNeighbours())
                {
                    Console.WriteLine(n.ToString());
                }
                Console.WriteLine("Neighbours of D");
                foreach (Node n in d.GetNeighbours())
                {
                    Console.WriteLine(n.ToString());
                }
            }
    
            private static void TestB()
            {
                //A <-> B <-> C
                Node a = new Node("a");
                Node b = new Node("b");
                Edge ab = a.ConnectTo(b);
                Node c = new Node("c");
                Edge bc = b.ConnectTo(c);
                Graph g = new Graph();
                g.Nodes.Add(a);
                g.Nodes.Add(b);
                g.Nodes.Add(c);
                g.Edges.Add(ab);
                g.Edges.Add(bc);
                Console.WriteLine(g.ToString());
    
                Console.WriteLine("Neighbours of B");
                foreach (Node n in b.GetNeighbours())
                {
                    Console.WriteLine(n.ToString());
                }
            }
    
            private static void TestA()
            {
                //A <-> B
                Node a = new Node("a");
                Node b = new Node("b");
                Edge ab = a.ConnectTo(b);
                Graph g = new Graph();
                g.Nodes.Add(a);
                g.Nodes.Add(b);
                g.Edges.Add(ab);
                Console.WriteLine(g.ToString());
            }
        }
    
        class Edge
        {
            public Edge(string name, Node a, Node b)
            {
                Name = name;
                A = a;
                B = b;
            }
    
            public Node A { get; private set; }
            public Node B { get; private set; }
            public string Name { get; private set; }
    
            public override string ToString() => $"{Name}";
        }
    
        class Node
        {
            public Node(string name)
            {
                Name = name;
                connectedEdges = new List<Edge>();
            }
    
            public string Name { get; private set; }
    
            private ICollection<Edge> connectedEdges;
            public IEnumerable<Edge> ConnectedEdges
            {
                get
                {
                    return connectedEdges.AsEnumerable();
                }
            }
    
            public void AddConnectedEdge(Edge e)
            {
                connectedEdges.Add(e);
            }
    
            public Edge ConnectTo(Node n)
            {
                //Create the edge with references to nodes
                Edge e = new Edge($"{Name} <-> {n.Name}", this, n);
                //Add edge reference to this node
                AddConnectedEdge(e);
                //Add edge reference to the other node
                n.AddConnectedEdge(e);
                return e;
            }
    
            public IEnumerable<Node> GetNeighbours()
            {
                foreach (Edge e in ConnectedEdges)
                {
                    //Have to figure which one is not this node
                    Node node = e.A != this ? e.A : e.B;
                    yield return node;
                }
            }
    
            public override string ToString() => $"{Name}";
        }
    
        class Graph
        {
            public Graph()
            {
                Nodes = new List<Node>();
                Edges = new List<Edge>();
            }
    
            public ICollection<Node> Nodes { get; set; }
            public ICollection<Edge> Edges { get; set; }
    
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
    
                str.AppendLine("Graph:");
                str.AppendLine("Nodes:");
                foreach (Node n in Nodes)
                {
                    str.AppendLine(n.ToString());
                }
                str.AppendLine("Edges:");
                foreach (Edge e in Edges)
                {
                    str.AppendLine(e.ToString());
                }
    
                return str.ToString();
            }
        }
    }
