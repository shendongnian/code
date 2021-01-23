    public class MultiListWrapper<T> : IEnumerable<T>
        where T : class, new()
    {
        private List<object[]> list = new List<object[]>();
        private Type[] fieldTypes;
        private int length = 0;
        public MultiListWrapper(int length, params object[] fields)
        {
            this.length = length;
            fieldTypes = fields.Select(f => f.GetType()).ToArray();
            for (int r = 0; r < length; r++)
            {
                var row = new object[fields.Length];
                for (int f = 0; f < fields.Length; f++)
                {
                    var field = fields[f];
                    row[f] = (field as Array).GetValue(r);
                }
                list.Add(row);
            }
        }
        public int Count { get { return length; } }
        public T this[int index]
        {
            get
            {
                if (index >= length)
                    throw new IndexOutOfRangeException();
                // Create the return item
                var item = new T();
                var properties = item.GetType().GetProperties();
                // Get fields from list item
                var listItem = list[index];
                for (int i = 0; i < listItem.Length; i++)
                {
                    if(properties[i].PropertyType.FullName != fieldTypes[i].FullName.Replace("[]", string.Empty))
                        throw new SettingsPropertyWrongTypeException(
                            string.Format("The type for Property '{0}' on the requested model '{1}' doesn't match the underlying list item property type", 
                            properties[i].Name,
                            typeof(T).FullName));
                    properties[i].SetValue(item, listItem[i]);
                }
                return item;
            }
        }
        private MultiListWrapperEnumerator<T> _enumerator;
        public IEnumerator<T> GetEnumerator()
        {
            if (_enumerator == default(MultiListWrapperEnumerator<T>))
            {
                _enumerator = new MultiListWrapperEnumerator<T>(this);
            }
            return _enumerator;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #region Enumerator for the wrapper
        private class MultiListWrapperEnumerator<T> : IEnumerator<T>
        where T : class, new()
        {
            private MultiListWrapper<T> _listWrapper;
            private int _index;
            public MultiListWrapperEnumerator(MultiListWrapper<T> listWrapper)
            {
                _listWrapper = listWrapper;
                _index = -1;
            }
            public void Dispose()
            {
            }
            public bool MoveNext()
            {
                _index++;
                if (_index >= _listWrapper.Count)
                    return false;
                return true;
            }
            public void Reset()
            {
                _index = -1;
            }
            public T Current
            {
                get { return _listWrapper[_index]; }
                private set { throw new NotImplementedException(); }
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
        #endregion
    }
