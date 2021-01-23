    public class CoreObject : IObjectCopy<CoreObject>
    {
        public CoreObject Copy()
        {
            return Copy<CoreObject>();
        }
        protected T Copy<T>()
            where T : CoreObject, new()
        {
            T t = new T();
            //implement copy logic:
            return t;
        }
    }
    public class Animal : CoreObject, IObjectCopy<Animal>
    {
        public new Animal Copy()
        {
            return Copy<Animal>();
        }
    }
