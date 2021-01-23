    // using System.Reflection;
    static PluginList()
    {
        list.AddRange(
            from t in Assembly.GetAssembly(typeof(PluginList)).GetTypes()
            where t.IsClass && t.GetInterfaces().Contains(typeof(Plugin))
            select new Func<Plugin>(() => {
                try
                {
                    return (Plugin)t.GetConstructor(new Type[] { }).Invoke(new object[] { });
                }
                catch
                {
                    return null;
                }
            })());
    }
