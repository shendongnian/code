    public class JarOfSweets : IJarOfSweets {
        public void Shuffle()
        {
            throw new NotImplementedException();
        }
        public ISweet TakeSweetFromJar()
        {
            throw new NotImplementedException();
        }
        int IReadOnlyCollection<ISweet>.Count
        {
            get { return 30; }
        }
        IEnumerator<ISweet> IEnumerable<ISweet>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
