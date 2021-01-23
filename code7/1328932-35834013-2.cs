	// Frequent operation using .NET Timer.
	System.Timers.Timer t = new System.Timers.Timer (1000);
	t.AutoReset = true;
	t.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => {
		t.Interval = 2000;
		RunOnUiThread (() => Toast.MakeText (this, "Hi", ToastLength.Short).Show ());
	};
	t.Start ();
	// Frequent operation using Android.OS.Handler
	handler = new Handler ();
	Action callback = null;
	callback = () => {
		//Do something after 100ms
		Toast.MakeText(this, "Hi", ToastLength.Short).Show();  
		handler.PostDelayed(callback, 2000);
	};
	handler.PostDelayed(callback, 1000);
