    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    namespace ObservableCollectionListCheck
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list = new List<string>();
                var oc = new ObservableWrapper<string>(list);
                oc.CollectionChanged += OnCollectionChanged;
                
                list.AddRange(new [] {"1","2","3"});
                
                Console.WriteLine($"List: {string.Join(" ",list)}");            
                Console.WriteLine($"ObservableWrapper: {string.Join(" ", oc)}");
                oc.Add("4");
                Console.WriteLine($"List: {string.Join(" ", list)}");
                Console.WriteLine($"ObservableWrapper: {string.Join(" ", oc)}");
                list.Add("5"); // OnCollectionChanged will not call
                Console.WriteLine($"List: {string.Join(" ", list)}");
                Console.WriteLine($"ObservableWrapper: {string.Join(" ", oc)}");
                Console.ReadLine();
            }
            private static void OnCollectionChanged(Object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
            {
                Console.WriteLine($"OnCollectionChanged:{notifyCollectionChangedEventArgs.Action}");
            }
        }
        public class ObservableWrapper<T> : IList<T>, INotifyCollectionChanged
        {
            private readonly IList<T> _internalList;
            public event NotifyCollectionChangedEventHandler CollectionChanged;
            private void RaiseCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
            {
                CollectionChanged?.Invoke(sender, args);
            }
            public ObservableWrapper(IList<T> list)
            {
                _internalList = list;
            }
            
            public IEnumerator<T> GetEnumerator()
            {
                return _internalList.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public void Add(T item)
            {
                _internalList.Add(item);
                RaiseCollectionChanged(this,new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,item));
            }
            public void Clear()
            {
                _internalList.Clear();
                RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
            public Boolean Contains(T item)
            {
                return _internalList.Contains(item);
            }
            public void CopyTo(T[] array, Int32 arrayIndex)
            {
                _internalList.CopyTo(array,arrayIndex);
            }
            public Boolean Remove(T item)
            {
                var result = _internalList.Remove(item);
                RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
                return result;
            }
            public Int32 Count => _internalList.Count;
            public Boolean IsReadOnly => false;
            public Int32 IndexOf(T item) => _internalList.IndexOf(item);
            
            public void Insert(Int32 index, T item)
            {
                _internalList.Insert(index,item);
                RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,item,index));
            }
            public void RemoveAt(Int32 index)
            {
                _internalList.RemoveAt(index);
                RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            }
            public T this[Int32 index]
            {
                get { return _internalList[index]; }
                set { _internalList[index] = value; }
            }
        }
    }
