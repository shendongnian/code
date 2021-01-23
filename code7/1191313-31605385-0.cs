    public interface ITreeNode<T> where T : ITreeNode<T>
    {
        T ParentNode { get; set; }
        ICollection<T> ChildNodes { get; set; }
    }
    public class FooNode : ITreeNode<FooNode>
    {
        public FooNode ParentNode { get; set; }
        public ICollection<FooNode> ChildNodes { get; set; }
    }
