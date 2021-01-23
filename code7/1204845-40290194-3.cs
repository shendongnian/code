    using System;
    using System.Runtime.Serialization;
    [Serializable]
    public class Visitor : ISerializable
    {
        private int Version;
        public string Name { get; private set; }
        public string IP { get; set: }
        public Visitor()
        {
            this.Version = 2;
        }
        public void ChangeName(string Name)
        {
            this.Name = Name;
            this.Version += 1;
        }
        protected Visitor(SerializationInfo info, StreamingContext context)
        {
            this.Version = info.GetInt32("Version");
            this.Name = info.GetString("Name");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Version", this.Version);
            info.AddValue("Name", this.Name);
        }
        [OnDeserialized]
        private void OnDeserialization(StreamingContext context)
        {
            switch (this.Version)
            {
                case 1:
                    //Handle versioning issues, if this
                    //deserialized version is one, so that
                    //it can play well once it's serialized as
                    //version two.
                    break;
            }
        }
    }
