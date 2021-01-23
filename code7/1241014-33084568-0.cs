    public void Configuration(IAppBuilder app)
    {
        ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
        ...
    }
