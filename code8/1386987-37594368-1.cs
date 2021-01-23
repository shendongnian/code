	[Activity(Label = "GetLocation.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		LocationBroadcastReciever _lbr;
		Button button;
		
		protected override void OnCreate(Bundle bundle)
		{
			// ... various OnCreate() code
		}
		
		protected override void OnResume()
		{
			base.OnResume();
			_lbr = new LocationBroadcastReciever();
			RegisterReceiver(lbr, new IntentFilter("test"));
		}
		
		protected override void OnPause()
		{
			UnregisterReceiver(_lbr);
			base.OnPause();
		}
		public void SetButtonText(string text)
		{
			button.Text = text;
		}
	}
