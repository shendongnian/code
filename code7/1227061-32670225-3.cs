    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
        public static void Main(string[] args)
        {
            var node3 = new Node
            {
                Id = 3,
                Children = new List<Node>()
            };
    		
            var n2Children = new List<Node>();
            n2Children.Add(node3);
    		
            var node2 = new Node
            {
                Id = 2,
                Children = n2Children
            };
    		
            var n1Children = new List<Node>();
            n1Children.Add(node2);
    
            var node1 = new Node
            {
                Id = 1,
                Children = n1Children
            };
    		
    		var n0Children = new List<Node>();
            n0Children.Add(node1);
    
            var node0 = new Node
            {
                Id = 0,
                Children = n0Children
            };
    		
    		SetDecendents(node0);
            Console.WriteLine(node0.Decendents);
    		
            SetDecendents(node1);
            Console.WriteLine(node1.Decendents);
    		
    		SetDecendents(node2);
            Console.WriteLine(node2.Decendents);
    		
    		SetDecendents(node3);
            Console.WriteLine(node3.Decendents);
    		
            Console.ReadLine();
        }
    
        public static int SetDecendents(Node n)
        {
    		
            if (n.Children.Count() == 0)
            {
                n.Decendents = 0;
            }
            else
            {
                n.Decendents = n.Children.Count() + n.Children.Sum(c => SetDecendents(c));
            }
    		
            return n.Decendents;
        }
    }
    
    public class Node
    {
        public int Id { get; set; }
        public int Decendents { get; set; }
        public ICollection<Node> Children { get; set; }
    }
