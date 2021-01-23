    [Serializable]
    public class NHibernateTransactionAttribute : OnMethodBoundaryAspect, IInstanceScopedAspect
    {
        [ImportMember("SessionFactory", IsRequired = true)] 
        public Property<ISessionFactory> SessionFactoryProperty;
        public override void OnEntry(MethodExecutionArgs args)
        {
            var session = this.SessionFactoryProperty.Get().CurrentSession;
            // ...
        }
        object IInstanceScopedAspect.CreateInstance(AdviceArgs adviceArgs)
        {
            return this.MemberwiseClone();
        }
        void IInstanceScopedAspect.RuntimeInitializeInstance()
        {
        }
        
        // ...
    }
