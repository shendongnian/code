    public abstract class Foo<T> : where T : CustomObject, new()
    {
        protected T _customObject;
        public Foo()
        {
            this.CustomObject = new T();
        }
    }
    public class Bar : Foo<BarCustomObject>
    {
    }
