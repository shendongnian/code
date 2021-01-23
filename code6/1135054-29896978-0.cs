    public class CurrentUserIDParameterBinding : HttpParameterBinding
    {
        public CurrentUserIDParameterBinding(HttpParameterDescriptor parameter)
            : base(parameter)
        {
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
        HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            Guid userId = /* my userid based on provider */;
            actionContext.ActionArguments[Descriptor.ParameterName] = userId;
            return Task.FromResult<object>(null);
        }
    }
    public class CurrentUserIDAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new CurrentUserIDParameterBinding(parameter);
        }
    }
