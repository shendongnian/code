        // Summary:
        // Defines a dictionary key/value pair that can be set or retrieved.
        [Serializable]
        [ComVisible(true)]
        public struct DictionaryEntry
        {            
            public DictionaryEntry(object key, object value);
    
            // Summary:
            //     Gets or sets the key in the key/value pair.
            //
            // Returns:
            //     The key in the key/value pair.
            public object Key { get; set; }
            //
            // Summary:
            //     Gets or sets the value in the key/value pair.
            //
            // Returns:
            //     The value in the key/value pair.
            public object Value { get; set; }
        }
