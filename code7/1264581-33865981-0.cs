    public class ClassA<T>
        where T : Foo<T>
    {
        public ClassA(T dataObject)
        {
            if (typeof(Bar<T>).IsAssignableFrom(typeof(T)))
            {
                // method 1, calling a generic function
                MethodInfo mi = typeof(ClassA<T>).GetMethod("SetBDataObject").MakeGenericMethod(typeof(Bar<T>));
                mi.Invoke(this, new object[] { dataObject });
                // method 2, doing it all with reflection
                Type type = typeof(ClassB<>).MakeGenericType(typeof(T));
                object x = Activator.CreateInstance(type);
                type.GetProperty("DataObject").SetValue(x, dataObject);
            }
        }
        public object SetBDataObject<TB> (TB obj)
            where TB : Bar<TB>
        {
            var x = new ClassB<TB>();
            x.DataObject = obj;
            return x;
        }
    }
