    public class ListWrapper<T> : IBindingList
    {
        private IList<T> _wrappedList;
        public ListWrapper(IList<T> wrappedList)
        {
            _wrappedList = wrappedList;
        }
        #region IBindingList implementation
        #region Necessary members
        public object this[int index]
        {
            get { return new Wrapper<T>(this, index); }//This wrapper have the Value property which is used as FieldName.
            set { Insert(index, value); }
        }
        public object AddNew()
        {
            _wrappedList.Add(default(T));
            return new Wrapper<T>(this, Count - 1);
        }
        public void RemoveAt(int index)
        {
            _wrappedList.RemoveAt(index);
        }
        public int Count { get { return _wrappedList.Count; } }
        public IEnumerator GetEnumerator()
        {
            return new ListWrapperEnumerator(this);
        }
        private class Wrapper<T>
        {
            private readonly ListWrapper<T> _listWrapper;
            private readonly int _index;
            public Wrapper(ListWrapper<T> listWrapper, int index)
            {
                _listWrapper = listWrapper;
                _index = index;
            }
            public T Value
            {
                get { return _listWrapper._wrappedList[_index]; }
                set { _listWrapper._wrappedList[_index] = value; }
            }
        }
        private class ListWrapperEnumerator : IEnumerator
        {
            private readonly ListWrapper<T> _listWrapper;
            private int _currentIndex;
            public ListWrapperEnumerator(ListWrapper<T> listWrapper)
            {
                _listWrapper = listWrapper;
                Reset();
            }
            public object Current
            {
                get { return _listWrapper[_currentIndex]; }
            }
            public bool MoveNext()
            {
                return _currentIndex++ < _listWrapper.Count;
            }
            public void Reset()
            {
                _currentIndex = -1;
            }
        }
        #endregion
        #region Optional members
        private bool GetValue(object value, out T result)
        {
            if (value is T)
            {
                result = (T)value;
                return true;
            }
            var wrapper = value as Wrapper<T>;
            if (wrapper != null)
            {
                result = wrapper.Value;
                return true;
            }
            result = default(T);
            return false;
        }
        public int Add(object value)
        {
            T result;
            if (GetValue(value, out result))
            {
                _wrappedList.Add(result);
                return _wrappedList.Count - 1;
            }
            return -1;
        }
        public void Clear()
        {
            _wrappedList.Clear();
        }
        public bool Contains(object value)
        {
            T result;
            if (GetValue(value, out result))
                return _wrappedList.Contains(result);
            return false;
        }
        public void CopyTo(Array array, int index)
        {
            for (int listIndex = 0; listIndex < _wrappedList.Count; listIndex++)
            {
                int arrayIndex = listIndex + index;
                if (arrayIndex >= array.Length)
                    return;
                array.SetValue(_wrappedList[listIndex], arrayIndex);
            }
        }
        public int IndexOf(object value)
        {
            T result;
            if (GetValue(value, out result))
                return _wrappedList.IndexOf(result);
            return -1;
        }
        public void Insert(int index, object value)
        {
            T result;
            if (GetValue(value, out result))
                _wrappedList.Insert(index, result);
        }
        public void Remove(object value)
        {
            T result;
            if (GetValue(value, out result))
                _wrappedList.Remove(result);
        }
        #endregion
        #region Settings
        public bool AllowEdit { get { return true; } }
        public bool AllowNew { get { return true; } }
        public bool AllowRemove { get { return true; } }
        public bool IsFixedSize { get { return false; } }
        public bool IsReadOnly { get { return false; } }
        public bool SupportsChangeNotification { get { return false; } }
        public bool SupportsSearching { get { return false; } }
        public bool SupportsSorting { get { return false; } }
        #endregion
        #region Not used members
        public void AddIndex(PropertyDescriptor property) { }
        public void ApplySort(PropertyDescriptor property, ListSortDirection direction) { }
        public int Find(PropertyDescriptor property, object key) { return -1; }
        public void RemoveIndex(PropertyDescriptor property) { }
        public void RemoveSort() { }
        public bool IsSorted { get { return false; } }
        public bool IsSynchronized { get { return false; } }
        public ListSortDirection SortDirection { get { return default(ListSortDirection); } }
        public PropertyDescriptor SortProperty { get { return null; } }
        public object SyncRoot { get { return null; } }
        public event ListChangedEventHandler ListChanged;
        #endregion
        #endregion
    }
