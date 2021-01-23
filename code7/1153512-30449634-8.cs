    public class CircularList<T> : IEnumerable<T>
    {
        private List<T> mylist = new List<T>();
        public T this[int index]
        {
            get
            {
                return this.mylist[index];
            }
            set
            {
                this.mylist.Insert(index, value);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.mylist.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
