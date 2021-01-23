    public interface IVertex<TVertex, TEdge>
            where TVertex : IVertex
            where TEdge : IEdge
    {
        bool AddEdge(TEdge e);
        TEdge FindEdge(TVertex v);
    }
    
    public interface IEdge<TVertex> where TVertex : IVertex
    {
        TVertex From { get; }
    }
