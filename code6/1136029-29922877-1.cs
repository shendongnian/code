    public class CustomSerializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (typeName == "ClipboardLibrary.ClipboardData")
            {
                return typeof(ClipboardLibrary.OtherNamespace.ClipboardData);
            }
            return Type.GetType(String.Format("{0}, {1}",
                    typeName, assemblyName));
        }
    }
    private ClipboardLibrary.OtherNamespace.ClipboardData DeSerialize(Stream stream)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Binder = new CustomSerializationBinder();
        return (ClipboardLibrary.OtherNamespace.ClipboardData)formatter.Deserialize(stream);
    }
