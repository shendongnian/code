    private const String NameField = "_name";  // For serialization
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // No need for an additional security check - everything is public.
            info.AddValue(NameField, _name, typeof(String));
        }
