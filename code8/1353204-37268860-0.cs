    protected override void OnCreate (Bundle bundle)
	{
		base.OnCreate (bundle);
		global::Xamarin.Forms.Forms.Init (this, bundle);
        global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
        LoadApplication (new Test.App ());
        this.ActionBar.SetIcon(Android.Resource.Color.Transparent);
	}
