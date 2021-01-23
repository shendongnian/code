    public class UserAwareHttpParameterBinding : HttpParameterBinding
    {
    	private readonly HttpParameterBinding _paramaterBinding;
    	private readonly HttpParameterDescriptor _httpParameterDescriptor;
    
    	public UserAwareHttpParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor)
    	{
    		_httpParameterDescriptor = descriptor;
    		_paramaterBinding = new FromBodyAttribute().GetBinding(descriptor);
    	}
    
    	public override async Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
    	{
    		await _paramaterBinding.ExecuteBindingAsync(metadataProvider, actionContext, cancellationToken);
    
    		var baseModel = actionContext.ActionArguments[_httpParameterDescriptor.ParameterName] as IUserAware;
    		if (baseModel != null)
    		{
    			baseModel.UserId = new Guid("6ed85eb7-e55b-4049-a5de-d977003e020f"); // Or get it form the actionContext.RequestContext!
    		}
    	}
    }
