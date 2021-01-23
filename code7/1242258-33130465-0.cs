    public sealed class SimpleSdkActivity : CodeActivity
    {
    	[Input("Account Name")]
    	[Default("Test Account")]
    	public InArgument<string> AccountName { get; set; }
    	protected override void Execute(CodeActivityContext executionContext)
    	{
    		//Create the tracing service
    		ITracingService tracingService = executionContext.GetExtension<ITracingService>();
    
    		//Create the context
    		IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
    		IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
    		IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
    		
    		var entityName = AccountName.Get<string>(executionContext);
    	}
    }
