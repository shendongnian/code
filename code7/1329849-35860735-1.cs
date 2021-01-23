    public class Example
    {
        public static void Main()
        {
            List<Node> nodes = new List<Node>
            {
              new Node {Id = 0, Title = "Node1"},
              new Node {Id = 1, Title = "Node2"},
              new Node {Id = 2, Title = "Node7"},
              new Node {Id = 3, Title = "Node3"},
              new Node {Id = 4, Title = "Node4"},
              new Node {Id = 5, Title = "Node5"},
              new Node {Id = 6, Title = "Node6"},
              new Node {Id = 7, Title = "Node8"},
              new Node {Id = 8, Title = "Node9"},
              new Node {Id = 9, Title = "Node10"},
              new Node {Id = 10, Title = "Node11"},
              new Node {Id = 11, Title = "Node12"},
              new Node {Id = 12, Title = "Node13"},
              new Node {Id = 13, Title = "Node14"},
              new Node {Id = 14, Title = "Node15"},
              new Node {Id = 15, Title = "Node16"},
              new Node {Id = 16, Title = "Node17"},
              new Node {Id = 17, Title = "Node18"},
              new Node {Id = 18, Title = "Node19"},
              new Node {Id = 19, Title = "Node20"},
              new Node {Id = 20, Title = "Node21"},
              new Node {Id = 21, Title = "Node22"},
              new Node {Id = 22, Title = "Node23"}
          };
            nodes[0].AddChild(nodes[3]);
            nodes[1].AddChild(nodes[3]);
            nodes[2].AddChild(nodes[4]);
            nodes[2].AddChild(nodes[5]);
            nodes[3].AddChild(nodes[6]);
            nodes[3].AddChild(nodes[7]);
            nodes[3].AddChild(nodes[8]);
            nodes[3].AddChild(nodes[9]);
            nodes[6].AddChild(nodes[10]);
            nodes[2].AddChild(nodes[11]);
            nodes[2].AddChild(nodes[12]);
            nodes[7].AddChild(nodes[13]);
            nodes[8].AddChild(nodes[14]);
            nodes[4].AddChild(nodes[15]);
            nodes[5].AddChild(nodes[15]);
            nodes[7].AddChild(nodes[15]);
            nodes[12].AddChild(nodes[16]);
            nodes[13].AddChild(nodes[16]);
            nodes[13].AddChild(nodes[17]);
            nodes[14].AddChild(nodes[18]);
            nodes[8].AddChild(nodes[19]);
            nodes[13].AddChild(nodes[20]);
            nodes[14].AddChild(nodes[20]);
            nodes[8].AddChild(nodes[21]);
            nodes[15].AddChild(nodes[21]);
            nodes[18].AddChild(nodes[22]);
            nodes[19].AddChild(nodes[22]);
            //Get all nodes by level
            //if any node does not have a parent it is by default in level 0
            var rootNodes = nodes.Where(i => i.IsRootElement);
                                   
            foreach (var rootNode in rootNodes)
            {
                PrintElementRecurcively(rootNode, null,0);
            }
            
            Console.ReadKey();
        }
        static void PrintElementRecurcively(Node nodeToPrint,Node parentNode,int depth)
        {                 
                System.Console.Write(string.Join("", Enumerable.Repeat("-", (depth*2))));
                System.Console.WriteLine("Node Id:{0}    Level:{1}     ParentId:{2}", nodeToPrint.Id, depth,
                    nodeToPrint.Parents == null ? "Unknown" : parentNode.Id.ToString());
                
                if (nodeToPrint.Childs==null)
                {
                    return;
                }
                foreach (var rootNode in nodeToPrint.Childs)
                {
                    PrintElementRecurcively(rootNode, nodeToPrint, depth+1);
                }  
        }
    }
    internal class Node
    {
        public List<Node> Parents { get;private set; }         
        public List<Node> Childs{get;private set;}        
        public int Id { get; set; }
        public string Title { get; set; }
        public void AddChild(Node newChild)
        {
            if (Childs == null)
            {
                Childs = new List<Node>();
            }
            Childs.Add(newChild);
            if (newChild.Parents==null)
            {
                newChild.Parents = new List<Node>();
            }
            newChild.Parents.Add(this);            
        }
        public Boolean IsRootElement
        {
            get
            {
                return Parents == null;	            
            }
        }
        //public int Level
        //{
        //    get
        //    {
        //        if(Parents==null)
        //        {
        //            return 0;
        //        }
        //        //If you have multiple parents with different level
        //        //then it's impossible to assign that node a fixed level
        //        //you need to took one stategy
        //        // return Parents.Min(i => i.Level);
        //        //return  Convert.ToInt32(Math.Floor(Parents.Average(i => i.Level)));
        //        return Parents.Max(i => i.Level);
        //    }
        //}
        
        
    }
