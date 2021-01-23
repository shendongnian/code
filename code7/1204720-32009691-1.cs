    /// <summary>
    /// Implements JavaScript Serialization and Deserialization for instances of the Dictionary&lt;int, object&gt; type.
    /// </summary>
    public class IntDictionaryConverter : JavaScriptConverter
    {
        /// <summary>
        /// Converts the provided dictionary into a Dictionary&lt;int, object&gt; object.
        /// </summary>
        /// <param name="dictionary">An IDictionary instance of property data stored as name/value pairs.</param>
        /// <param name="type">The type of the resulting object.</param>
        /// <param name="serializer">The JavaScriptSerializer instance.</param>
        /// <returns>The deserialized object.</returns>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            // Validate arguments
            if (dictionary == null) throw new ArgumentNullException("dictionary");
            if (serializer == null) throw new ArgumentNullException("serializer");
            Dictionary<int, object> deserializedDictionary = new Dictionary<int, object>();
            foreach (KeyValuePair<string, object> entry in dictionary)
            {
                int intKey = 0;
                if (!int.TryParse(entry.Key, out intKey))
                    throw new InvalidOperationException("Cannot deserialize the dictionary because of invalid number string");
                deserializedDictionary.Add(intKey, entry.Value);
            }
            return deserializedDictionary;
        }
        /// <summary>
        /// Builds a dictionary of name/value pairs.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="serializer">The object that is responsible for the serialization.</param>
        /// <returns>An object that contains key/value pairs that represent the object’s data.</returns>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            // Validate arguments
            if (obj == null) throw new ArgumentNullException("obj");
            if (serializer == null) throw new ArgumentNullException("serializer");
            // Get the dictionary to convert
            Dictionary<int, object> dictionary = (Dictionary<int, object>)obj;
            // Build the converted dictionary
            Dictionary<string, object> convertedDictionary = new Dictionary<string, object>();
            foreach (KeyValuePair<int, object> entry in dictionary)
                convertedDictionary.Add(entry.Key.ToString(), entry.Value);
            
            return convertedDictionary;
        }
        /// <summary>
        /// Gets a collection of the supported types.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new Type[]
                {
                    typeof(Dictionary<int, object>)
                };
            }
        }
    }
