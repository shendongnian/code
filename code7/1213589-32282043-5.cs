    interface IGraph {
         IEnumerable<Vertex> Vertices { get;}
    }
     class GraphBase<TVertex> : IGraph where TVertex : Vertex {
         public List<TVertex> Vertices { get; set; }
         IEnumerable<Vertex> IGraph.Vertices { get { return Vertices; }}
    }
  
