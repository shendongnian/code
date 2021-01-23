    public class BSTNode<T> : IComparable<BSTNode<T>> where T : IComparable<T>
    {
        public T Data { get; set; }
        public BSTNode<T> LeftChild { get; private set; }
        public BSTNode<T> RightChild { get; private set; }
        public int CompareTo(BSTNode<T> other)
        {
            return this.Data.CompareTo(other.Data);
        }
    }
