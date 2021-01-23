      public LocalizedDisplayNameAttribute(string resourceKey)
            : base(resourceKey)
        {
        ResourceKey = resourceKey;
    }
    public string ResourceKey { get; set; }
    public override string DisplayName
    {
        get
        {
            string value = null;
            var ioc = Abp.Dependency.IocManager.Instance;
            var localizationManager = ioc.IocContainer.Resolve<ILocalizationManager>();
            value = localizationManager.GetString(MMConsts.LocalizationSourceName, ResourceKey, Thread.CurrentThread.CurrentUICulture);
            return value;
        }
    }
