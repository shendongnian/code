    [Serializable]
    public class A : I
    {
        public String X { get; set; }
        public String Y { get; set; }
        public String MyZ { get; set; }
        public A()
        {
        }
        // Special ctor for deserialization
        public A(SerializationInfo info, StreamingContext context)
        {
            // This example uses an array of property names as a context object.
            IEnumerable<string> props = context.Context as IEnumerable<string>;
            foreach(SerializationEntry entry in info)
            {
                if (props.Contains(entry.Name))
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
        }
        // ISerializable implementation
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // This example uses an array of property names as a context object.
            IEnumerable<string> props = context.Context as IEnumerable<string>;
            if (props.Contains("X"))
            {
                info.AddValue("X", X);
            }
            if (props.Contains("Y"))
            {
                info.AddValue("Y", Y);
            }
            if (props.Contains("MyZ"))
            {
                info.AddValue("MyZ", MyZ);
            }
        }
    }
