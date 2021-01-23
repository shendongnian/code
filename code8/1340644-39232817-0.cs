    using UnityEngine;
    using System.Collections.Generic;
    using System.Collections;
    
    [System.Serializable]
    public class SerializableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TKey> keys = new List<TKey>();
    
        [SerializeField]
        private List<TValue> values = new List<TValue>();
    
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
    
        public ICollection<TKey> Keys
        {
            get
            {
                return ((IDictionary<TKey, TValue>)dictionary).Keys;
            }
        }
    
        public ICollection<TValue> Values
        {
            get
            {
                return ((IDictionary<TKey, TValue>)dictionary).Values;
            }
        }
    
        public int Count
        {
            get
            {
                return ((IDictionary<TKey, TValue>)dictionary).Count;
            }
        }
    
        public bool IsReadOnly
        {
            get
            {
                return ((IDictionary<TKey, TValue>)dictionary).IsReadOnly;
            }
        }
    
        public TValue this[TKey key]
        {
            get
            {
                return ((IDictionary<TKey, TValue>)dictionary)[key];
            }
    
            set
            {
                ((IDictionary<TKey, TValue>)dictionary)[key] = value;
            }
        }
    
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }
    
        public void OnAfterDeserialize()
        {
            dictionary = new Dictionary<TKey, TValue>();
    
            if (keys.Count != values.Count)
            {
                throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable.", keys.Count, values.Count));
            }
    
            for (int i = 0; i < keys.Count; i++)
            {
                var keyThing = keys[i];
                var valueThing = values[i];
                Add(keys[i], values[i]);
            }
        }
    
        public void Add(TKey key, TValue value)
        {
            ((IDictionary<TKey, TValue>)dictionary).Add(key, value);
        }
    
        public bool ContainsKey(TKey key)
        {
            return ((IDictionary<TKey, TValue>)dictionary).ContainsKey(key);
        }
    
        public bool Remove(TKey key)
        {
            return ((IDictionary<TKey, TValue>)dictionary).Remove(key);
        }
    
        public bool TryGetValue(TKey key, out TValue value)
        {
            return ((IDictionary<TKey, TValue>)dictionary).TryGetValue(key, out value);
        }
    
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ((IDictionary<TKey, TValue>)dictionary).Add(item);
        }
    
        public void Clear()
        {
            ((IDictionary<TKey, TValue>)dictionary).Clear();
        }
    
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)dictionary).Contains(item);
        }
    
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<TKey, TValue>)dictionary).CopyTo(array, arrayIndex);
        }
    
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)dictionary).Remove(item);
        }
    
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)dictionary).GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)dictionary).GetEnumerator();
        }
    }
