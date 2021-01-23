     public class ContextResolver : IContextResolver
     {
         public ISomeContext ResolveContext()
         {
              return DependencyFactory.Resolve<SomeContext>();
         }
     }
