    public class FilteredEnumerator<T> : System.Collections.Generic.IEnumerator<T>
    {
        readonly System.Collections.Generic.IEnumerator<T> enumerator;
        readonly System.Func<T, bool> filter; // could be null
        public FilteredEnumerator(System.Collections.Generic.IEnumerable<T> enumerable) : this(enumerable, null) { }
        public FilteredEnumerator(System.Collections.Generic.IEnumerable<T> enumerable, System.Func<T, bool> filter)
        {
            if (enumerable == null)
                throw new System.ArgumentNullException();
            this.enumerator = enumerable.GetEnumerator();
            this.filter = filter; // could be null for unconditional enumeration.
        }
        #region IEnumerator<T> Members
        public T Current { get { return enumerator.Current; } }
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            enumerator.Dispose();
        }
        #endregion
        #region IEnumerator Members
        object System.Collections.IEnumerator.Current { get { return Current; } }
        public bool MoveNext()
        {
            while (enumerator.MoveNext())
            {
                if (filter == null || filter(enumerator.Current))
                    return true;
            }
            return false;
        }
        public void Reset()
        {
            enumerator.Reset();
        }
        #endregion
    }
