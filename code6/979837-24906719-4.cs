    public class RequireInterception : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (model.Services.Contains(typeof(IEventuallyRegistered)))
            {
                model.Interceptors.Add(new InterceptorReference(typeof(EventuallyRegisteredInterceptor)));
            }
        }
    }
