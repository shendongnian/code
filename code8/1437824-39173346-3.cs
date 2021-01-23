    public class UnityFallbackProviderStrategy : BuilderStrategy
    {
        private IUnityContainer _container;
        public UnityFallbackProviderStrategy(IUnityContainer container)
        {
            _container = container;
        }
        #region Overrides of BuilderStrategy
        /// <summary>
        /// Called during the chain of responsibility for a build operation. The
        /// PreBuildUp method is called when the chain is being executed in the
        /// forward direction.
        /// </summary>
        /// <param name="context">Context of the build operation.</param>
        public override void PreBuildUp(IBuilderContext context)
        {
            NamedTypeBuildKey key = context.OriginalBuildKey;
            // Checking if the Type we are resolving is registered with the Container
            if (!_container.IsRegistered(key.Type))
            {
                // If not we first get our default IServiceProvider and then try to resolve the type with it
                // Then we save the Type in the Existing Property of IBuilderContext to tell Unity
                // that it doesnt need to resolve the Type
                context.Existing = _container.Resolve<IServiceProvider>(UnityFallbackProviderExtension.FALLBACK_PROVIDER_NAME).GetService(key.Type);
            }
            // Otherwise we do the default stuff
            base.PreBuildUp(context);
        }
        #endregion
    }
