	public override void LoadPlugins(MvvmCross.Platform.Plugins.IMvxPluginManager pluginManager)
	{
		base.LoadPlugins(pluginManager);
		pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.Messenger.PluginLoader>();
		pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.Color.PluginLoader>();
		pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.Visibility.PluginLoader>();
	}
