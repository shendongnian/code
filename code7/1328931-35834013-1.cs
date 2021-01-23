	[BroadcastReceiver]
	[IntentFilter(new string[] {"com.company.BROADCAST"})]
	public class Alarm : BroadcastReceiver
	{
		public Alarm ()
			: base()
		{
			Console.WriteLine ("Alarm made: " + this.GetHashCode ());
		}
		public Alarm(System.IntPtr handle, Android.Runtime.JniHandleOwnership transfer)
			: base(handle, transfer)
		{
			Console.WriteLine ("Alarm made: " + this.GetHashCode ());
		}
		// ...
	}
	
