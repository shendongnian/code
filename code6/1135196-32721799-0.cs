    namespace YourNamespace
    {
	[Application]
	public class App : Application
	{
		public ParseObject currentBusiness { get; set;}
		public App (IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}
		public override void OnCreate ()
		{
			base.OnCreate ();
			currentBusiness = new ParseObject ("Business");
		}
	}
    }
