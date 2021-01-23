    protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
    {
        base.FillTargetFactories(registry);
            
        registry.RegisterFactory(new MvxCustomBindingFactory<TextView>("Summary", textView => new SummaryTextViewBinding(textView)));
    }
