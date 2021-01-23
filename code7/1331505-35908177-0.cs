    public class AdjacencyTree<T> : AdjacencyTree
    {
        public AdjacencyTree(int entityId, int entityTypeId) : base(entityId, entityTypeId) { }
        public T Value { get; set; }
    }
