    using System;
    public class Node {
        public String Name {get; set;}
        public int[] Links {get; set;} 
    }
    public class Program
    {
	    private static Node[] nodes = new[] {
		    new Node { Name = "A", Links = new[] { 1 } },
		    new Node { Name = "B", Links = new[] { 2, 3 } },
		    new Node { Name = "C", Links = new[] { 4, 5 } },
		    new Node { Name = "D", Links = new[] { 6 } }
	    };
	    private static void PrintPath(int depth, string path)
	    {
		    if (depth == nodes.Length) 
		    {
			    Console.WriteLine(path);
		    }
		    else 
		    {
			    foreach(var link in nodes[depth].Links)
			    {
				    PrintPath(
                        depth+1, 
                        string.Format("{0}{1}{2} ", path, nodes[depth].Name, link));
			    }
		    }
	    }
	
	    public static void Main()
	    {
		    PrintPath(0, string.Empty);
	    }
    } 
