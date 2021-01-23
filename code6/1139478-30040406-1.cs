    [Serializable]
    public class Foo : ISerializable
    {
        public int Bar { get; set; }
        public Foo() { }
        public Foo(SerializationInfo info, StreamingContext context)
        {
            var enumerator = info.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                Debug.WriteLine(string.Format("{0} of type {1}: {2}", current.Name, current.ObjectType, current.Value));
                if (current.Name == "Bar" && current.ObjectType == typeof(int))
                {
                    Bar = (int)current.Value;
                    break;
                }
                else if (current.Name == "<Bar>k__BackingField" && current.ObjectType == typeof(bool))
                {
                    var old = (bool)current.Value;
                    Bar = (old ? 1 : 0); // Or whatever.
                }
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bar", Bar);
        }
    }
