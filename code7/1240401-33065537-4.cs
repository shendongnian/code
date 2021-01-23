    using Android.Runtime;
    namespace SomeName
    {
	[Application]
	public class App : Application
	{
		public string Name { get; set;}
		public App (IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}
		public override void OnCreate ()
		{
			base.OnCreate ();
			Name = "";
		}
	}
    }
