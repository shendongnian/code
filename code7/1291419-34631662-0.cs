    namespace Sitecore.Mvc.Pipelines.Response.RenderRendering
    {
    	public class EnterRenderingContext : RenderRenderingProcessor
    	{
    		public override void Process(RenderRenderingArgs args)
    		{
    			Assert.ArgumentNotNull(args, "args");
    			if (args.Rendered)
    			{
    				return;
    			}
    			this.EnterContext(args.Rendering, args);
    		}
    
    		protected virtual void EnterContext(Rendering rendering, RenderRenderingArgs args)
    		{
    			IDisposable item = RenderingContext.EnterContext(rendering);
    			args.Disposables.Add(item);
    		}
    	}
    }
