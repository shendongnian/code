    using MvvmCross.Plugins.PictureChooser;
    using MvvmCross.Plugins.PictureChooser.WindowsStore;
    using Cirrious.CrossCore.Plugins;
    . . .
    protected override IMvxPluginManager CreatePluginManager()
    {
        Mvx.RegisterType<IMvxPictureChooserTask, MvxPictureChooserTask>();
        return base.CreatePluginManager();
    }
