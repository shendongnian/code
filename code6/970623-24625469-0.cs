    public class ConfigurableScopeBindingModule : NinjectModule
    {
        private readonly Action<IBindingInSyntax<object>> scopeConfigurator;
        public ConfigurableScopeBindingModule(Action<IBindingInSyntax<object>> scopeConfigurator)
        {
            this.scopeConfigurator = scopeConfigurator;
        }
        public override void Load()
        {
            this.BindAndApplyScoping(x => x.Bind(typeof(string)).ToSelf());
        }
        private void BindAndApplyScoping(Func<IBindingRoot, IBindingInSyntax<object>> binding)
        {
            this.scopeConfigurator(binding(this));
        }
    }
