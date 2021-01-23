    public interface UrlEncodeSerializable
    {
        /// <summary>
        /// Prepares any complex data for serialization in the preferred form.
        /// After this finished executing, all data to serialize should be available
        /// as simple types in the attributed properties. Note that the actual URL encode
        /// serializer simply calls the .ToString() of any objects it encounters.
        /// </summary>
        void PrepareData();
    }
