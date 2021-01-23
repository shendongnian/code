    [Serializable]
    public class MyObject 
    {
      public string n1;
      [NonSerialized] public int n2;
      public String str;
    [OnSerializing()]
    internal void OnSerializingMethod(StreamingContext context)
    {
        n1= "This value went into the data file during serialization.";
    }
    [OnSerialized()]
    internal void OnSerializedMethod(StreamingContext context)
    {
        n1 = "This value was reset after serialization.";
    }
    [OnDeserializing()]
    internal void OnDeserializingMethod(StreamingContext context)
    {
        n1 = "This value was set during deserialization";
    }
    [OnDeserialized()]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        n1 = "This value was set after deserialization.";
    }
    }
    var obj = new MyObject();
    // Open a file and serialize the object into binary format.
    Stream stream = File.Open("DataFile.txt", FileMode.Create);
    BinaryFormatter formatter = new BinaryFormatter();
    formatter.Serialize(stream, obj);
    // Deserialize the object from the data file.
    obj = (TestSimpleObject)formatter.Deserialize(stream);
