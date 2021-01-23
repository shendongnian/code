    public class RoseTreeEnumerator<T> : IEnumerator<T>, IEnumerable<T>
    {
        public RoseTree<T> OriginalTree { get; private set; }
        private Stack<Lazy<RoseTree<T>>> TreeQueue { get; set; }
        private RoseTree<T> CurrentRoseTree { get; set; }
        public RoseTreeEnumerator(RoseTree<T> tree)
        {
            OriginalTree = tree;
            TreeQueue = new Stack<Lazy<RoseTree<T>>>();
            TreeQueue.Push(new Lazy<RoseTree<T>>(() => tree));
            CurrentRoseTree = null;
        }  
        #region IEnumerator<T> Members
        
        public T Current
        {
            get { return CurrentRoseTree.Value; }
        }
        public void Dispose()
        {
        }
        #endregion
        #region IEnumerator Members
        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            if (TreeQueue.Any())
            {
                CurrentRoseTree = TreeQueue.Pop().Value;
                foreach (var tree in CurrentRoseTree.Children.Reverse())
                {
                    TreeQueue.Push(tree);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            TreeQueue.Clear();
            CurrentRoseTree = null;
            TreeQueue.Push(new Lazy<RoseTree<T>>(() => OriginalTree));
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this;
        }
        #endregion
    }
