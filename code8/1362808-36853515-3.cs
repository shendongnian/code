	[Activity (Label = "MyApp", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            // ...
			Application.RegisterComponentCallbacks(new LifecycleCallbacks());
            // ...
		}
	}
