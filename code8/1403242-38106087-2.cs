    class BSTNode<TKey, TValue> : IEnumerable<BSTNode<TKey, TValue>>
    {
        public IEnumerator<BSTNode<TKey, TValue>> GetEnumerator()
        {
            var stack = new Stack<BSTNode<TKey, TValue>>();
            var current = this;
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    yield return current;
                    current = current.Right;
                }
            }
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        public BSTNode<TKey, TValue> Left { get; set; }
    
        public BSTNode<TKey, TValue> Right { get; set; }
    }
