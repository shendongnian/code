    public class RegistrationTrackingExtension : UnityContainerExtension
    {
        private ConcurrentDictionary<NamedTypeBuildKey, bool> registrations = new ConcurrentDictionary<NamedTypeBuildKey, bool>();
        protected override void Initialize()
        {
            base.Context.Registering += Context_Registering;
            base.Context.Strategies.Add(new ValidateRegistrationStrategy(this.registrations), UnityBuildStage.PreCreation);
        }
        private void Context_Registering(object sender, RegisterEventArgs e)
        {
            var buildKey = new NamedTypeBuildKey(e.TypeTo, e.Name);
            this.registrations.AddOrUpdate(buildKey, true, (key, oldValue) => true);
        }
        public class ValidateRegistrationStrategy : BuilderStrategy
        {
            private ConcurrentDictionary<NamedTypeBuildKey, bool> registrations = new ConcurrentDictionary<NamedTypeBuildKey, bool>();
            public ValidateRegistrationStrategy(ConcurrentDictionary<NamedTypeBuildKey, bool> registrations)
            {
                this.registrations = registrations;
            }
            public override void PreBuildUp(IBuilderContext context)
            {
                if (!this.registrations.ContainsKey(context.BuildKey))
                {
                    Exception e = new Exception("Type was not explicitly registered in the container.");
                    throw new ResolutionFailedException(context.BuildKey.Type, context.BuildKey.Name, e, context);
                }
            }
        }
    }
