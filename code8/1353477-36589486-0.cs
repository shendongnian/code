    public class IdentityResolutionExtension : UnityContainerExtension
    {
        public IdentityResolutionExtension(Func<IOwinContext> getOwinContext)
        {
            GetOwinContext = getOwinContext;
        }
        protected Func<IOwinContext> GetOwinContext { get; }
        protected override void Initialize()
        {
            Context.Strategies.Add(new IdentityTypeMappingStrategy(GetOwinContext), UnityBuildStage.TypeMapping);
        }
        class IdentityTypeMappingStrategy : BuilderStrategy
        {
            private readonly Func<IOwinContext> _getOwinContext;
            private static readonly MethodInfo IdentityTypeResolverMethodInfo =
                typeof (OwinContextExtensions).GetMethod("Get");
            public IdentityTypeMappingStrategy(Func<IOwinContext> getOwinContext)
            {
                _getOwinContext = getOwinContext;
            }
            public override void PreBuildUp(IBuilderContext context)
            {
                if (context.BuildComplete || context.Existing != null)
                    return;
                var resolver = IdentityTypeResolverMethodInfo.MakeGenericMethod(context.BuildKey.Type);
                var results = resolver.Invoke(null, new object[]
                {
                    _getOwinContext()
                });
                context.Existing = results;
                context.BuildComplete = results != null;
            }
        }
    }
