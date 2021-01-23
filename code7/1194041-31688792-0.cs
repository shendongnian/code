    public class AllowActionAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext context)
      {
         var builder = new StringBuilder();
         foreach (var routeVal in context.RouteData.Values)
         {
            builder.Append('.');
            builder.Append(routeVal.Value);
         }
         string path = builder.ToString();
         if ( /* path doesn't match the User's action Role */ )
         {
            // reject the action 
            context.Result = new EmptyResult();
         }
         else
         {
            // allow the action
            base.OnActionExecuting(context);
         }
      }
    }
