	public override void LoadPlugins(MvvmCross.Platform.Plugins.IMvxPluginManager pluginManager)
	{
		base.LoadPlugins(pluginManager);
        pluginManager.EnsurePluginLoaded<Chance.MvvmCross.Plugins.UserInteraction>();
	}
