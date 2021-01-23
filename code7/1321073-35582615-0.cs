    public interface IVertex<TV, TE>
    {
        TV Value { get; }
        bool AddEdge(IEdge<TV, TE> e);
        IEdge<TV, TE> FindEdge(IVertex<TV, TE> v);
    }
    public interface IEdge<TV, TE> 
    {
        TE Value { get; }
        IVertex<TV, TE> From { get; }
    }
