    public class FallbackSerializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {Clipboard.GetData
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
        formatter.Binder = new FallbackSerializationBinder();
        return (ClipboardLibrary.OtherNamespace.ClipboardData)formatter.Deserialize(stream);
    }
