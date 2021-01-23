    class MyBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            // the base.ConfigureContainer setup all build in prism services
            base.ConfigureContainer();
            //register your own stuff
        }
    }
