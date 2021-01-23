    protected override void OnCreate (Bundle bundle)
    {
         base.OnCreate (bundle);
         #region Resolver Init
         SimpleContainer container = new SimpleContainer();
         container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
         container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
         container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
        ....
    }
