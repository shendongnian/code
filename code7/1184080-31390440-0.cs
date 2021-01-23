    public interface INodeData
    {
        string Name { get; }
    }
    public class NodeData<T> : INodeData
    {
        public string Name { get; private set; }
        public T Value { get; private set; }
        public NodeData(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
