    // Base class for objects to be serialized as "[...]" instead of "{...}"
    public abstract class SerializedAsArray : IEnumerable<object>
    {
        IEnumerator<object> IEnumerable<object>.GetEnumerator() =>
            AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() =>
            AsEnumerable().GetEnumerator();
        protected abstract IEnumerable<object> AsEnumerable();
    }
    // will be serialized as: [87,99]
    public class Foo : SerializedAsArray
    {
        public string Key1;
        public string Key2;
    
        protected override IEnumerable<object> AsEnumerable()
        {
            yield return Key1;
            yield return Key2;
        }
    }
