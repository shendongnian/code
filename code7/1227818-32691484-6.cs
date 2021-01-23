    public List(IEnumerable<T> collection)
    {
        if (collection == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
        }
        ICollection<T> is2 = collection as ICollection<T>;
        if (is2 != null)
        {
            int count = is2.Count;
            if (count == 0)
            {
                this._items = List<T>._emptyArray;
            }
            else
            {
                this._items = new T[count];
                is2.CopyTo(this._items, 0);
                this._size = count;
            }
        }
        else
        {
            this._size = 0;
            this._items = List<T>._emptyArray;
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    this.Add(enumerator.Current);
                }
            }
        }
    }
