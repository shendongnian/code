    public class JarOfSweets : IJarOfSweets{
        public List<ISweet> _list = new List<ISweet>();
        public void Shuffle()
        {
            throw new NotImplementedException();
        }
        public ISweet TakeSweetFromJar()
        {
            throw new NotImplementedException();
        }
        public void Add(Sweet sweet)
        {
            _list.Add(sweet);
        }
        public int Count
        {
            get { return _list.Count; }
        }
        public IEnumerator<ISweet> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
