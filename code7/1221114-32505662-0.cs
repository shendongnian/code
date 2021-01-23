    [Serializable]
    public class NHibernateTransactionAttribute : OnMethodBoundaryAspect
    {
        public ISessionFactory SessionFactory { get; set; }
        public override void RuntimeInitialize(MethodBase method)
        {
            // Initialize the SessionFactory according to the container configuration.
            ObjectFactory.BuildUp(this);
        }
        // ...
    }
