    public class RegisterCustomRoute
    {
      public virtual void Process(PipelineArgs args)
      {
        RouteTable.Routes.MapRoute("CustomRoute", "some/route/{controller}/{action}/{id}");
      }
    }
