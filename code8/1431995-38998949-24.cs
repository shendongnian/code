    public class Bar // <T> or not depending on your choice
    // You can add this constraint to avoid value types (as int):
    //   where T : class
    {
        Dictionary<Type, Type> _container = new Dictionary<Type, Type>();
        {
            {typeof(IFoo), typeof(Foo)}
        };
        public T DoBarStuff() // <T> or not depending on your choice
        // You can add this constraint to avoid value types (as int):
        //   where T : class
        {
            // get fooStuff
            return Activator.CreateInstance(_container[typeof(T)]);
            // You will get an error if T is not in the container
            // or if _container[typeof(T)] is not instantiable
            // or doesn't have a default constructor.
        }
    }
