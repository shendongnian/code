     public class IOCContainer
     {
        static Dictionary<Type, Func<object>> registrations = new Dictionary<Type, Func<object>>();
        public static void Register<TService, TImpl>() where TImpl : TService
        {
            registrations.Add(typeof(TService), () => Resolve(typeof(TImpl)));
        }
        public static void Register<TService>(TService instance)
        {
            registrations.Add(typeof(TService), () => instance);
        }
        public static TService Resolve<TService>()
        {
            return (TService)Resolve(typeof(TService));
        }
        private static object Resolve(Type serviceType)
        {
            Func<object> creator;
            if (registrations.TryGetValue(serviceType, out creator)) return creator();
            if (!serviceType.IsAbstract) return CreateInstance(serviceType);
            else throw new InvalidOperationException("No registration for " + serviceType);
        }
        private static object CreateInstance(Type implementationType)
        {
            var ctor = implementationType.GetConstructors().Single();
            var parameterTypes = ctor.GetParameters().Select(p => p.ParameterType).ToList();
            var dependencies = parameterTypes.Select(Resolve).ToArray();            
            return Activator.CreateInstance(implementationType, dependencies);
        }
    }
