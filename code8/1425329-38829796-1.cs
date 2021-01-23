    class WorkflowServiceFactory : IWorkflowServiceFactory
    {
        private IUnityContainer _container;
        public GetServiceByEntity(IWorkflowableEntity entity)
        {
            Type t = typeof(IDataService<>);
            Type fulltype = t.MakeGenericType(new [] { entity.GetType() });
            return _container.Resolve(fulltype);
        }
    }
