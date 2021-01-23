    internal class Node
    {
       private int ID { get; private set; }
       private string NodeQuestion { public get; public set; }
       private int State { public get; public set; } // 0 for Non-Visited, 1 for Visited
       private Node Left { public get; public set; }
       private Node Right { public get; public set; }
       
       public Node(...)
       {
         ....
       }
       .
       .
       .
    }
