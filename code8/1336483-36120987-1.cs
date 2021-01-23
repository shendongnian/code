    [ProtoContract]
    public class GraphNode<T> where T : new()
    {
        readonly NodeList<T> neighbors = new NodeList<T>();
        public GraphNode()
        {
            this.Value = new T();
        }
        public GraphNode(T value)
            : this()
        {
            this.Value = value;
        }
        [ProtoMember(1, AsReference = true)]
        public T Value { get; set; }
        // Do not serialize the list of neighbors directly!  
        // Instead this will be serialized by the NodeList<T> owned by the Graph<T>
        [ProtoIgnore]
        public NodeList<T> Neighbors { get { return neighbors; } }
    }
    [ProtoContract(IgnoreListHandling = true)]
    public class NodeList<T> : Collection<GraphNode<T>> where T : new()
    {
        [ProtoContract]
        class GraphNodeNeighborsProxy
        {
            [ProtoMember(1, AsReference = true)]
            public GraphNode<T> Node { get; set; }
            [ProtoMember(2, AsReference = true, DataFormat = DataFormat.Group)]
            public ICollection<GraphNode<T>> Neighbors
            {
                get
                {
                    return Node == null ? null : Node.Neighbors;
                }
            }
        }
        [ProtoMember(1, AsReference = true, DataFormat = DataFormat.Group)]
        IEnumerable<GraphNode<T>> Nodes
        {
            get
            {
                return new SerializationCollectionWrapper<GraphNode<T>, GraphNode<T>>(this, n => n, (c, n) => c.Add(n)); 
            }
        }
        [ProtoMember(2, DataFormat = DataFormat.Group)]
        IEnumerable<GraphNodeNeighborsProxy> NeighborsTable
        {
            get
            {
                return new SerializationCollectionWrapper<GraphNode<T>, GraphNodeNeighborsProxy>(
                    this,
                    n => new GraphNodeNeighborsProxy { Node = n },
                    (c, proxy) => {}
                    );
            }
        }
    }
    [ProtoContract]
    public class Graph<T> where T : new()
    {
        readonly private NodeList<T> nodeSet = new NodeList<T>();
        public Graph() { }
        public GraphNode<T> AddNode(GraphNode<T> node)
        {
            // adds a node to the graph
            nodeSet.Add(node);
            return node;
        }
        public GraphNode<T> AddNode(T value)
        {
            // adds a node to the graph
            return AddNode(new GraphNode<T>(value));
        }
        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to)
        {
            from.Neighbors.Add(to);
        }
        [ProtoMember(2, AsReference = true, DataFormat = DataFormat.Group)]
        public NodeList<T> Nodes
        {
            get
            {
                return nodeSet;
            }
        }
    }
    public class SerializationCollectionWrapper<TFrom, TTo> : ICollection<TTo>
    {
        readonly ICollection<TFrom> collection;
        readonly Func<TFrom, TTo> mapTo;
        readonly Action<ICollection<TFrom>, TTo> add;
        public SerializationCollectionWrapper(ICollection<TFrom> collection, Func<TFrom, TTo> mapTo, Action<ICollection<TFrom>, TTo> add)
        {
            if (collection == null || mapTo == null || add == null)
                throw new ArgumentNullException();
            this.collection = collection;
            this.mapTo = mapTo;
            this.add = add;
        }
        ICollection<TFrom> Collection { get { return collection; } }
        #region ICollection<TTo> Members
        public void CopyTo(TTo[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }
        public int Count
        {
            get { return Collection.Count; }
        }
        public bool IsReadOnly
        {
            get { return Collection.IsReadOnly; }
        }
        public void Add(TTo item)
        {
            add(Collection, item);
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(TTo item)
        {
            throw new NotImplementedException();
        }
        public bool Remove(TTo item)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IEnumerable<TTo> Members
        public IEnumerator<TTo> GetEnumerator()
        {
            foreach (var item in Collection)
                yield return mapTo(item);
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
