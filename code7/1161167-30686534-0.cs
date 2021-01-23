    using System;
    using System.Collections.Generic;
    namespace Example
    {
        public class UniqueList<T> : IList<T>
        {
            private readonly List<T> _list;
            private readonly HashSet<T> _hashset;
            
            public UniqueList()
            {
                _list = new List<T>();
                _hashset = new HashSet<T>();
            }
    
            public UniqueList(IEqualityComparer<T> comparer)
            {
                _list = new List<T>();
                _hashset = new HashSet<T>(comparer);
            }
            
            void ICollection<T>.Add(T item)
            {
                Add(item);
            }
    
            public bool Add(T item)
            {
                var added = _hashset.Add(item);
                if (added)
                {
                    _list.Add(item);
                }
                return added;
            }
    
            public void RemoveAt(int index)
            {
                _hashset.Remove(_list[index]);
                _list.RemoveAt(index);
            }
    
            public T this[int index]
            {
                get { return _list[index]; }
                set
                {
                    var oldItem = _list[index];
                    _hashset.Remove(oldItem);
                    var added = _hashset.Add(value);
                    if (added)
                    {
                        _list[index] = value;
                    }
                    else
                    {
                        //Put the old item back before we raise a exception.
                        _hashset.Add(oldItem);
                        throw new InvalidOperationException("Object already exists.");
                    }
                }
            }
    
            public int IndexOf(T item)
            {
                return _list.IndexOf(item);
            }
            
            void IList<T>.Insert(int index, T item)
            {
                Insert(index, item);
            }
    
            public bool Insert(int index, T item)
            {
                var added = _hashset.Add(item);
                if (added)
                {
                    _list.Insert(index, item);
                }
                return added;
            }
    
            public void Clear()
            {
                _list.Clear();
                _hashset.Clear();
            }
    
            public bool Contains(T item)
            {
                return _hashset.Contains(item);
            }
    
            public void CopyTo(T[] array, int arrayIndex)
            {
                _list.CopyTo(array, arrayIndex);
            }
    
            public bool IsReadOnly
            {
                get { return false; }
            }
    
            public bool Remove(T item)
            {
                var removed = _hashset.Remove(item);
                if (removed)
                {
                    _list.Remove(item);
                }
                return removed;
            }
    
            public int Count
            {
                get { return _list.Count; }
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                return _list.GetEnumerator();
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
        }
    }
