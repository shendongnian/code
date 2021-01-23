    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
            #region Resolver Init
            SimpleContainer container = new SimpleContainer();
            container.Register<IDevice>(t => AppleDevice.CurrentDevice);
            container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
            container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
            Resolver.SetResolver(container.GetResolver());
            #endregion
        ....
    }
