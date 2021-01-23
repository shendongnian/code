    public class MyBootstrapper : DefaultNancyBootstrapper
    {
        public MyBootstrapper () : base()
        {
            JsonSettings.RetainCasing = true;
        }
    }
