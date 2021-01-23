    public class OwinCancellationTokenBinding : HttpParameterBinding
    {
        public OwinCancellationTokenBinding(HttpParameterDescriptor parameter)
            : base(parameter)
        {
        }
    
        public override Task ExecuteBindingAsync(
            ModelMetadataProvider metadataProvider, 
            HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            actionContext.ActionArguments[Descriptor.ParameterName]
                = actionContext.Request.GetOwinContext().Request.CallCancelled;
    
            return Task.FromResult<object>(null);
        }
    }
