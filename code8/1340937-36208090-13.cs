    public interface UrlEncodeSerializable
    {
        /// <summary>
        /// Prepares any non-string data for serialization in the preferred form.
        /// After this finished executing, all data to serialize should be available
        /// in the attributed properties. Note that the actual URL Encode Serializer
        /// simply calls the .ToString() of any objects it encounters.
        /// </summary>
        void PrepareData();
    }
