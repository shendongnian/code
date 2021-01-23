    public class DictionaryNotificationWrapper<TKey, TValue> : IDictionary<TKey, TValue>, INotifyPropertyChanged
    {
        #region Fields
        private IDictionary<TKey, TValue> innerDictionary;
        
        #endregion
        #region Constructors
        public DictionaryNotificationWrapper(IDictionary<TKey, TValue> innerDictionary)
        {
            if (innerDictionary == null)
                throw new ArgumentNullException("innerDictionary", "The inner dictionary is null");
            
            this.innerDictionary = innerDictionary;
        }
        #endregion
        #region IDictionary implementation
        public TValue this[TKey key]
        {
            get
            {
                return this.innerDictionary[key];
            }
            set
            {
                this.innerDictionary[key] = value;
                this.OnPropertyChanged("Item[]");
                this.OnPropertyChanged("Count");
            }
        }
        #endregion
        #region not implemented IDictionary members - you are free to finish the work
        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }
        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }
        public ICollection<TKey> Keys
        {
            get { throw new NotImplementedException(); }
        }
        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }
        public ICollection<TValue> Values
        {
            get { throw new NotImplementedException(); }
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get { throw new NotImplementedException(); }
        }
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
