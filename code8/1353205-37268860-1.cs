    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
    	global::Xamarin.Forms.Forms.Init ();
        global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();
        LoadApplication (new Test.App ());
        return base.FinishedLaunching (app, options);
    }
