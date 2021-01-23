	[Service(Name="com.sushihangover.androidservice.MyMostAmazingService", Exported = true)]
	[IntentFilter(new String[] { "myservice" }, Categories = new[] { Intent.CategoryDefault })]
	public class PsiServiceHost : Service
	{
		public override IBinder OnBind(Intent intent)
		{
			return null;
		}
		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			Log.Debug("SO", "MyMostAmazingService Has Been Started");
			return base.OnStartCommand(intent, flags, startId);
		}
	}
