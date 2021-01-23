    public abstract class NodeDataBase
    {
        public string Name { get; set; }
        public NodeData(string name)
        {
            this.Name = name;
        }
        // this isn't actually needed, but might be helpful
        public abstract object GetValue();
        
    }
    public class NodeData<T> : NodeDataBase
    {
        public T Value { get; set; }
        public NodeData(string name, T value) : base(name)
        {
            this.Value = value;
        }
        public override object GetValue()
        {
            return Value;
        }
    }
