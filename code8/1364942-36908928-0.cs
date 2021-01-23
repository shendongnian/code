    public abstract class SuperClass
    {
        public static T CreateFrom(ISomething something)
        {
            return (T)Activator.CreateInstance(typeof(T), something);
        }
    }
    public class InheritedClass : SuperClass
    {
        public InheritedClass(ISomething something)
        {}
    }
