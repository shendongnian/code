    public class Bar // <T> or not depending on your choice
    {
        Dictionary<Type, Type> _container = new Dictionary<Type, Type>();
        {
            {typeof(IFoo), typeof(Foo)}
        };
        public T DoBarStuff() // <T> or not depending on your choice
        {
            // get fooStuff
            return Activator.CreateInstance(_container[typeof(T)]);
            // You will get an error if T is not in the container
            // or if _container[typeof(T)] is not instantiable
            // or doesn't have a default constructor.
        }
    }
