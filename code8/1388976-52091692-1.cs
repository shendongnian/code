    protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
    {
        base.FillTargetFactories(registry);
        registry.RegisterPropertyInfoBindingFactory(
                typeof(ViewEnabledTargetBinding),
                typeof(View), "Enabled");
    }
