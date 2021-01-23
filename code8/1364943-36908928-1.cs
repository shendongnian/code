    public abstract class SuperClass
    {
        protected abstract void Initialize(ISomething something);
        public static T CreateFrom(ISomething something) where T : new()
        {
            T result = new T();
            T.Initialize(something);
        }
    }
    public class InheritedClass : SuperClass
    {
        public InheritedClass()
        {}
        protected override Initialize(ISomething something)
        {}
    }
