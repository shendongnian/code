    public override void OnInvoke(MethodInterceptionArgs args)
        {
            CacheMinutes = EngineContext.Current.Resolve<AppSettings>().Cache.TTL.GlobalSetting;
            CacheEnabled = !EngineContext.Current.Resolve<AppSettings>().Cache.IgnoreCache;
            var methodInfo = args.Method as MethodInfo;
    ......
    
