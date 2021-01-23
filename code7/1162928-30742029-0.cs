    internal static class IApplicationBuilderExtensions
    {
      public static void UseOwin(
        this IApplicationBuilder app,
        Action<IAppBuilder> owinConfiguration )
      {
        app.UseOwin(
          addToPipeline =>
            {
              addToPipeline(
                next =>
                  {
                    var builder = new AppBuilder();
                    owinConfiguration( builder );
                    builder.Run( ctx => next( ctx.Environment ) );
                    Func<IDictionary<string, object>, Task> appFunc =
                      (Func<IDictionary<string, object>, Task>)
                      builder.Build( typeof( Func<IDictionary<string, object>, Task> ) );
                    return appFunc;
                  } );
            } );
      }
    }
