    public class Graph
    {
        public IEnumerable<Node> Nodes(Graph g)
        {
            Contract.Requires(g != null);
            Contract.Ensures(Contract.ForAll(Contract.Result<IEnumerable<Nodei>>, node => node != null));
            foreach (var x in g.MethodForGettingNodes())
            yield return x;
        }
    }
