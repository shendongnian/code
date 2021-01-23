    private Dictionary<string, IPlugins.IPlugin> _Plugins = new     Dictionary<string, IPlugins.IPlugin>();
    public void LoadPlugins()
    {
	lock (static_LoadPlugins_IpluginType_Init) {
		try {
			if (InitStaticVariableHelper(static_LoadPlugins_IpluginType_Init)) {
				static_LoadPlugins_IpluginType = typeof(IPlugins.IPlugin);
			}
		} finally {
			static_LoadPlugins_IpluginType_Init.State = 1;
		}
	}
	string ServerPath = HttpContext.Current.Server.MapPath("~") + "Plugins";
	dynamic Plugins = io.Directory.GetFiles(ServerPath);
	foreach (string PluginPath in Plugins) {
		dynamic Assembly = system.Reflection.Assembly.LoadFile(PluginPath);
		Type PluginClass = Assembly.GetTypes.Where(T => T.GetInterface("IPlugin") != null).First;
		IPlugins.IPlugin MyPlugin = Activator.CreateInstance(PluginClass);
		MyPlugin.Load(httpcontext.Current);
		_Plugins.@add(PluginClass.ToString, MyPlugin);
	}
    }
    static bool     InitStaticVariableHelper(Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag flag)
    {
	if (flag.State == 0) {
		flag.State = 2;
		return true;
	} else if (flag.State == 2) {
		throw new Microsoft.VisualBasic.CompilerServices.IncompleteInitialization();
	} else {
		return false;
	}
    }
