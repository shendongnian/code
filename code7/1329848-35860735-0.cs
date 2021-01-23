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
            nodes[0].Child = nodes[3];
            nodes[1].Child = nodes[3];
            nodes[2].Child = nodes[4];
            nodes[2].Child = nodes[5];
            nodes[3].Child = nodes[6];
            nodes[3].Child = nodes[7];
            nodes[3].Child = nodes[8];
            nodes[3].Child = nodes[9];
            nodes[6].Child = nodes[10];
            nodes[2].Child = nodes[11];
            nodes[2].Child = nodes[12];
            nodes[7].Child = nodes[13];
            nodes[8].Child = nodes[14];
            nodes[4].Child = nodes[15];
            nodes[5].Child = nodes[15];
            nodes[7].Child = nodes[15];
            nodes[12].Child = nodes[16];
            nodes[13].Child = nodes[16];
            nodes[13].Child = nodes[17];
            nodes[14].Child = nodes[18];
            nodes[8].Child = nodes[19];
            nodes[13].Child = nodes[20];
            nodes[14].Child = nodes[20];
            nodes[8].Child = nodes[21];
            nodes[15].Child = nodes[21];
            nodes[18].Child = nodes[22];
            nodes[19].Child = nodes[22];
    
            //Get all nodes by level
            //if any node does not have a parent it is by default in level 0
    
            var levelWiseNodes = nodes.GroupBy(i => i.Level);
    
            
            foreach (var Levels in levelWiseNodes)
            {
                System.Console.WriteLine("Level:{0}", Levels.Key);
    
                foreach (var item in Levels)
                {
                    System.Console.Write(string.Join("", Enumerable.Repeat("-", item.Level + 1)));
                    System.Console.WriteLine("Node Id:{0} Level:{1}", item.Id, item.Level);
                }                
            }
    
            Console.ReadKey();
        }
    }
    
        internal class Node
        {
            public Node Parent { get; set; }
        
            private Node m_child;
        
            public Node Child
            {
                get { return m_child; }
                set
                {
                    m_child = value;
                    value.Parent = this;
                    LevelChanged();
                }
            }
        
            public int Id { get; set; }
            public string Title { get; set; }
        
            public int Level { get; private set; }
        
            protected void LevelChanged()
            {
                this.Child.Level = this.Level + 1;
        
                if (this.Child.Child != null)
                {
                    this.Child.Child.LevelChanged();
                }
            }
        }
