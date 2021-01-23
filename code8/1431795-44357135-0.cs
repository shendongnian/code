    public override bool FinishedLaunching (UIApplication app, NSDictionary options)
    {
        // switch
        UISwitch.Appearance.OnTintColor = UIColor.FromRGB(0xFF, 0x00, 0x00);
        // required Xamarin.Forms code
        Forms.Init ();
        LoadApplication (new App ());
        return base.FinishedLaunching (app, options);
    }
