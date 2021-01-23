    using System;
    using System.Xml.Serialization;
    using System.IO;
    public static class Clone
    {
        /// Clones the specified instance. 
        /// Returns a new instance of an object.
        public static T Clone(this T instance){
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, instance);
            stream.Seek(0, SeekOrigin.Begin);
            return serializer.Deserialize(stream) as T;
        }
    }
