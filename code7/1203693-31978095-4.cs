    abstract class AbstractFactory<T> where T : class
    {
        protected Dictionary<Enum, Type> types;
    
        protected AbstractFactory()
        {
            types = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                     from type in assembly.GetTypes()
                     let attributes = type.GetCustomAttributes(typeof(FactoryAttribute), true)
                     where (attributes.Any()) && (typeof(T).IsAssignableFrom(type)) && (type.IsClass)
                     select
                     new
                     {
                         dietEnum = (Enum)((FactoryAttribute)attributes.First()).Something,
                         dietType = type
                     }).ToDictionary(x => x.dietEnum, x => x.dietType);
        }
        public T CreateInstance(Enum id, params object[] param)
        {	
            return (T)Activator.CreateInstance(types[id], param);
        }
    }
