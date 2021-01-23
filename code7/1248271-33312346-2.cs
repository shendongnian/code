    public class Serializer<T> : ISerializer<T>
    {
        public string Read(T obj)
        {
            //Use reflection here to read object properties
        }
        public void Write(T obj, string data)
        {
            //Use reflection here to set object properties
        }
    }
