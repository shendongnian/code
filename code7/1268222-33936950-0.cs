	[BroadcastReceiver]
	[IntentFilter(new[] { Intent.ActionBootCompleted }, Priority = (int)IntentFilterPriority.LowPriority)]
	public class BootReceiver : BroadcastReceiver
	{ 
		public override void OnReceive(Context context, Intent intent)
		{
			Intent serviceStart = new Intent(context, typeof(MainActivity));
			serviceStart.AddFlags (ActivityFlags.NewTask);
			context.StartActivity(serviceStart);                
		}
	}
