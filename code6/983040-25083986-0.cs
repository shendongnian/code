    using System;
    using System.Collections.Generic;
    
    namespace Bizmonger.Client.Infrastructure
    {
        public class ServiceLocator
        {
            #region Members
            Dictionary<Type, object> _dictionary = new Dictionary<Type, object>();
            static ServiceLocator _serviceLocator = null;
            #endregion
    
            public static ServiceLocator Instance
            {
                get
                {
                    if (_serviceLocator == null)
                    {
                        _serviceLocator = new ServiceLocator();
                    }
    
                    return _serviceLocator;
                }
            }
    
            public object this[Type key] 
            {
                get
                {
                    if (!_dictionary.ContainsKey(key))
                    {
                        _dictionary.Add(key, Activator.CreateInstance(key));
                    }
    
                    return _dictionary[key];
                }
                set
                {
                    _dictionary[key] = value;
                }
            }
    
            public bool ContainsKey(Type type)
            {
                return _dictionary.ContainsKey(type);
            }
    
            public void Load(object data)
            {
                if (data == null) { return; }
    
                RemoveExisting(data);
    
                _dictionary.Add(data.GetType(), data);
            }
    
            public void Load(Type type, object data)
            {
                if (data == null) { return; }
    
                RemoveExisting(data);
    
                _dictionary.Add(type, data);
            }
    
            #region Helpers
            private void RemoveExisting(object data)
            {
                bool found = _dictionary.ContainsKey(data.GetType());
    
                if (found)
                {
                    _dictionary.Remove(data.GetType());
                }
            }
            #endregion
        }
    }
