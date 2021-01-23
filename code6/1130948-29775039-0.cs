    public class FunqJobActivator : JobActivator
    {
        private const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
        private static readonly _activateMethod = 
            typeof(FunqJobActivator).GetMethod("InternalActivateJob", flags);
        private Funq.Container _container;
        public FunqJobActivator(Funq.Container container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }
        public override object ActivateJob(Type type)
        {
            // this will allow calling InternalActivateJob<T> with typeof(T) == type.
            var method = _activateMethod.MakeGenericMethod(new [] { type });
            return method.Invoke(this, null);
        }
        private object InternalActivateJob<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
