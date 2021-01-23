    public class DefaultRegistrationFallbackConfiguration : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Context.Registering += this.AppendRemapPolicy;
        }
        public override void Remove()
        {
            this.Context.Registering -= this.AppendRemapPolicy;
        }
        private void AppendRemapPolicy(object sender, RegisterEventArgs e)
        {
            if (e.Name != null)
                return;
            if (e.TypeFrom != null && e.TypeTo != null)
                this.Context.Policies.SetDefault<IBuildKeyMappingPolicy>(new MapBuildKeyToDefaultPolicy(e.TypeFrom, e.TypeTo));
            if (e.LifetimeManager == null)
                return;
            throw new NotImplementedException("TODO: lifetime management");
        }
    }
