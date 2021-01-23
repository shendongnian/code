    public class RedrowEnterRenderingContext : Sitecore.Mvc.Pipelines.Response.RenderRendering.EnterRenderingContext
    {
    	private const string _developmentKeyword = "$development";
    
    	private IDevelopmentQueryServiceV2 _coUkDevelopmentQueryService = ServiceLocator.Current.GetInstance<IDevelopmentQueryServiceV2>();
    
    
    	protected override void EnterContext(Rendering rendering, RenderRenderingArgs args)
    	{
            //Make your changes to the items that are used to build the context here
    		if (args.PageContext != null &&
    			args.PageContext.Item != null &&
    			args.Rendering.DataSource.Contains(_developmentKeyword) &&
    			args.PageContext.Item.TemplateID.Guid == TemplateIdConst.V2Development)
    		{
    
    			args.Rendering.DataSource = args.Rendering.DataSource.Replace(_developmentKeyword, 
    				args.PageContext.Item.Paths.Path);
    		}
            //build the context using the existing functionality
    		base.EnterContext(rendering, args);
    	}
    }
