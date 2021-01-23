    public class MyPlugin : IPlugin 
    {
        public void Register(IAppHost appHost)
        {
            appHost.RegisterService<MyPluginService>("/myendpoint");
        }
    }
