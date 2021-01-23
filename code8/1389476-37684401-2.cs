    public enum TemplatesEnum
    {
        Template1,
        Template2,
    }
    [Serializable]
    public class A : I
    {
        public String X { get; set; }
        public String Y { get; set; }
        public String MyZ { get; set; }
        public A() {}
        // Special ctor for deserialization
        public A(SerializationInfo info, StreamingContext context)
        {
            // Ignore context while deserializing.
            foreach (SerializationEntry entry in info)
            {
                switch (entry.Name)
                {
                    case "X":
                        X = (string)entry.Value;
                        break;
                    case "Y":
                        Y = (string)entry.Value;
                        break;
                    case "MyZ":
                        MyZ = (string)entry.Value;
                        break;
                }
            }
        }
        // ISerializable implementation
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            TemplatesEnum templ = (TemplatesEnum)context.Context;
            // Determin which properties should be serialized depending on the context.
            switch(templ)
            {
                case TemplatesEnum.Template1:
                    info.AddValue("X", X);
                    break;
                case TemplatesEnum.Template2:
                    info.AddValue("X", X);
                    info.AddValue("Y", Y);
                    break;
            }
        }
    }
