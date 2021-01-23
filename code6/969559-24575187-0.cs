    using System.Collections.Generic;
    
    namespace DynamicdataGridBindingTest {
        /// <summary>
        /// This is a minimal implementation of a Dictionary, which will never throw KeyNotFoundException if trying to access a value for a key which hasn't been set.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        public class DictionaryWithReturnValue<TKey, TValue> {
            #region Private Fields
    
            private readonly Dictionary<TKey, TValue> m_dictionary;
    
            #endregion
    
            #region Constructor
    
            /// <summary>
            /// Initializes a new instance of the <see cref="DictionaryWithReturnValue{TKey, TValue}"/> class.
            /// </summary>
            public DictionaryWithReturnValue() {
                m_dictionary = new Dictionary<TKey, TValue>();
            }
    
            #endregion
    
            #region Indexer
    
            /// <summary>
            /// Gets or sets the value for the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <returns>The value, if it has been previously set; otherwise default(TValue)</returns>
            public TValue this[TKey key] {
                get {
                    TValue value;
                    return m_dictionary.TryGetValue(key, out value) ? value : default(TValue);
                }
                set { m_dictionary[key] = value; }
            }
    
            #endregion
    
            #region Public Methods
    
            /// <summary>
            /// Adds the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="value">The value.</param>
            public void Add(TKey key, TValue value) {
                m_dictionary.Add(key, value);
            }
    
            /// <summary>
            /// Removes the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            public void Remove(TKey key) {
                m_dictionary.Remove(key);
            }
    
            /// <summary>
            /// Clears all the entries.
            /// </summary>
            public void Clear() {
                m_dictionary.Clear();
            }
    
            #endregion
        }
    }
