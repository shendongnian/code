    public class Node
    {
       public int Weight { get; set; }
       public int Connected { get; set; }
    }
    // You can use either an array of lists or a list of lists
    List<List<Node>> graph = new List<List<Node>>();
            // The index is the edge label - e.g. arr[0] is the edge labeled "0"
            graph[0] = new List<Node>()
            {
                new Node() { Weight = 175, Connected = 1 },
                new Node() { Weight= 100, Connected = 2 }
                // Etc...
            };
            graph[1] = new List<Node>()
            {
                // Basically, to represent an undirected edge you're representing two weighted edges
                // (i.e. a connection from 1 -> 2 and a connection from 2 -> 1)
                // This also makes directed edges easy to represent
                new Node() { Weight = 175, Connected = 1 }
                // Etc...
            };
