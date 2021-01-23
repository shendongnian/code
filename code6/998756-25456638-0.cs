    [Flags]
    public enum DataToSerialize
    {
        None = 0,
        GUID = (1<<0),
        Names = (1<<1),
    }
    public static class SerializationFlags
    {
        [ThreadStatic]
        static DataToSerialize? dataToSerialize;
        public static DataToSerialize? DataToSerialize
        {
            get { return dataToSerialize; }
            set { dataToSerialize = value; }
        }
    }
    public class Student
    {
        public Guid Id {get; set;}
        public String FirstName {get; set;}
        public String LastName { get; set; }
        public bool ShouldSerializeId()
        {
            return SerializationFlags.DataToSerialize == null || (SerializationFlags.DataToSerialize.Value & DataToSerialize.GUID) != DataToSerialize.None;
        }
        public bool ShouldSerializeFirstName()
        {
            return SerializationFlags.DataToSerialize == null || (SerializationFlags.DataToSerialize.Value & DataToSerialize.Names) != DataToSerialize.None;
        }
        public bool ShouldSerializeLastName()
        {
            return SerializationFlags.DataToSerialize == null || (SerializationFlags.DataToSerialize.Value & DataToSerialize.Names) != DataToSerialize.None;
        }
    }
