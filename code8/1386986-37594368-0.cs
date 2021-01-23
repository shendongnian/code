    [BroadcastReceiver(Enabled = true)]
	[IntentFilter(new [] { "test" })]
	public class LocationBroadcastReciever : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			/* My program never get this far, so I have not been able
			   to confirm if the bellow code works or not (its from
			   another example I saw). */
			string text = intent.GetStringExtra("title");
			((MainActivity)context).SetButtonText(text);
			InvokeAbortBroadcast();
		}
	}
