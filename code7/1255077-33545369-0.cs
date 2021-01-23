    // The legacy savegame data. Keep it as it is.
    [Serializable]
    public class Savegame
    {
        // ... the legacy fields
    }
    // The new savegame data. This implements ISerializable
    [Serializable]
    public class SavegameNew : Savegame, ISerializable
    {
        // this constructor will execute on deserialization. You will deserialize
        // both the legacy and new types here.
        private SavegameNew(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry entry in info)
            {
                // you can iterate the serialized elements like this
                // if this is a new format you will get the new elements, too
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // custom serialization of the new type
        }
    }
