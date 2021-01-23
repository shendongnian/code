    // will be serialized as: [87,99]
    public class Foo : IEnumerable<object>
    {
        public string Key1;
        public string Key2;
    
        IEnumerator<object> IEnumerable<object>.GetEnumerator() => EnumerateFields().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => EnumerateFields().GetEnumerator();
        IEnumerable<object> EnumerateFields()
        {
            yield return Key1;
            yield return Key2;
        }
    }
