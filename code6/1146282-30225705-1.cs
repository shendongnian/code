    public List(IEnumerable<T> collection) {
        if (collection==null)
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
        Contract.EndContractBlock();
 
        ICollection<T> c = collection as ICollection<T>;
        if( c != null) {
            int count = c.Count;
            if (count == 0)
            {
                _items = _emptyArray;
            }
            else {
                _items = new T[count];
                c.CopyTo(_items, 0);
                _size = count;
            }
        }    
        else {                
            _size = 0;
            _items = _emptyArray;
            // This enumerable could be empty.  Let Add allocate a new array, if needed.
            // Note it will also go to _defaultCapacity first, not 1, then 2, etc.
            
            using(IEnumerator<T> en = collection.GetEnumerator()) {
                while(en.MoveNext()) {
                    Add(en.Current);                                    
                }
            }
        }
    }
