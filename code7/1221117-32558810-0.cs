    [Serializable]
    public sealed class NHibernateTransactionAttribute : OnMethodBoundaryAspect, IInstanceScopedAspect
    {
        [ImportMember("Session", IsRequired = true)] 
        public Property<ISession> SessionProperty;
    
        public override void OnEntry(MethodExecutionArgs args)
        {
            var session = this.SessionProperty.Get();
            session.Transaction.Begin();
        }
    
        public override void OnSuccess(MethodExecutionArgs args)
        {
            var session = this.SessionProperty.Get();
            session.Transaction.Commit();
        }
    
        public override void OnException(MethodExecutionArgs args)
        {
            var session = this.SessionProperty.Get();
            session.Transaction.Rollback();
        }
    
        public override void OnExit(MethodExecutionArgs args)
        {
            var session = this.SessionProperty.Get();
            session.Close();
        }
    
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return this.MemberwiseClone();
        }
    
        public void RuntimeInitializeInstance()
        {
        }
    }
