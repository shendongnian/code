        public ObservableCollection(List<T> list)
            : base((list != null) ? new List<T>(list.Count) : list)
        {
            // Workaround for VSWhidbey bug 562681 (tracked by Windows bug 1369339).
            // We should be able to simply call the base(list) ctor.  But Collection<T>
            // doesn't copy the list (contrary to the documentation) - it uses the
            // list directly as its storage.  So we do the copying here.
            // 
            CopyFrom(list);
        }
 
        public ObservableCollection(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
 
            CopyFrom(collection);
        }
