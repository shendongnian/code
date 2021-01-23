       public class JsonWrapper
        {
            public string ID { get; set; }
            public List<Fd> fd { get; set; }
        }
    
     public class Fd
        {
            public string titie { get; set; }
            public string type { get; set; }
            public Views views { get; set; }
        }
    
    public class Views
        {
            public Graph graph { get; set; }
        }
    
    public class Graph
        {
            public bool show { get; set; }
            public State state { get; set; }
        }
    
     public class State
        {
            public string group { get; set; }
            public List<string> series { get; set; }
            public string graphType { get; set; }
        }
