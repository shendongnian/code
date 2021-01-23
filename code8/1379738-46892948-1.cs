    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace Model
    {
        public class StringBackedList<T> : IList<T>
        {
            private readonly Accessor<string> _backingStringAccessor;
            private readonly IList<T> _backingList;
    
            public StringBackedList(Expression<Func<string>> expr)
            {
                _backingStringAccessor = new Accessor<string>(expr);
    
                var initialValue = _backingStringAccessor.Get();
                if (initialValue == null)
                    _backingList = new List<T>();
                else
                    _backingList = JsonConvert.DeserializeObject<IList<T>>(initialValue);
            }
    
            public T this[int index] {
                get => _backingList[index];
                set { _backingList[index] = value; Store(); }
            }
    
            public int Count => _backingList.Count;
    
            public bool IsReadOnly => _backingList.IsReadOnly;
    
            public void Add(T item)
            {
                _backingList.Add(item);
                Store();
            }
    
            public void Clear()
            {
                _backingList.Clear();
                Store();
            }
    
            public bool Contains(T item)
            {
                return _backingList.Contains(item);
            }
    
            public void CopyTo(T[] array, int arrayIndex)
            {
                _backingList.CopyTo(array, arrayIndex);
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                return _backingList.GetEnumerator();
            }
    
            public int IndexOf(T item)
            {
                return _backingList.IndexOf(item);
            }
    
            public void Insert(int index, T item)
            {
                _backingList.Insert(index, item);
                Store();
            }
    
            public bool Remove(T item)
            {
                var res = _backingList.Remove(item);
                if (res)
                    Store();
                return res;
            }
    
            public void RemoveAt(int index)
            {
                _backingList.RemoveAt(index);
                Store();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return _backingList.GetEnumerator();
            }
    
            public void Store()
            {
                _backingStringAccessor.Set(JsonConvert.SerializeObject(_backingList));
            }
        }
        // this class comes from https://stackoverflow.com/a/43498938/2698119
        public class Accessor<T>
        {
            private Action<T> Setter;
            private Func<T> Getter;
    
            public Accessor(Expression<Func<T>> expr)
            {
                var memberExpression = (MemberExpression)expr.Body;
                var instanceExpression = memberExpression.Expression;
                var parameter = Expression.Parameter(typeof(T));
                if (memberExpression.Member is PropertyInfo propertyInfo)
                {
                    Setter = Expression.Lambda<Action<T>>(Expression.Call(instanceExpression, propertyInfo.GetSetMethod(), parameter), parameter).Compile();
                    Getter = Expression.Lambda<Func<T>>(Expression.Call(instanceExpression, propertyInfo.GetGetMethod())).Compile();
                }
                else if (memberExpression.Member is FieldInfo fieldInfo)
                {
                    Setter = Expression.Lambda<Action<T>>(Expression.Assign(memberExpression, parameter), parameter).Compile();
                    Getter = Expression.Lambda<Func<T>>(Expression.Field(instanceExpression, fieldInfo)).Compile();
                }
    
            }
    
            public void Set(T value) => Setter(value);
            public T Get() => Getter();
        }
    }
