    [Serializable]
    public class MyClass: ISerializable
    {
        private string stringField;
        private object objectField;
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (stringField != null)
                info.AddValue("str", stringField);
            if (objectField != null)
                info.AddValue("obj", objectField);
        }
        // the special constructor for deserializing
        private MyClass(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry entry in info)
            {
                switch (entry.Name)
                {
                    case "str":
                        stringField = (string)entry.Value;
                        break;
                    case "obj":
                        objectField = entry.Value;
                        break;
                }
            }
        }
    }
