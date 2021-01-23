	[IntentFilter(new string[] { "android.provider.Telephony.SMS_RECEIVED" }, Priority = (int)IntentFilterPriority.HighPriority)]
	public class SMSReceiver : Android.Content.BroadcastReceiver
	{
		public static readonly string INTENT_ACTION = "android.provider.Telephony.SMS_RECEIVED";
		public override void OnReceive(Context context, Intent intent)
		{
			InvokeAbortBroadcast();
			try
			{
				if (intent.Action != INTENT_ACTION) return;
				var bundle = intent.Extras;
				if (bundle == null) {
					return;
				}
				var pdus = bundle.Get("pdus").ToArray<Java.Lang.Object>();
				var msgs = new SmsMessage[pdus.Length];
				var sb = new StringBuilder();
				String sender = null;
				for(int i=0; i<msgs.Length; i++){
					
					msgs[i] = SmsMessage.CreateFromPdu((byte[])pdus[i]);
					String messageBody = msgs[i].MessageBody;
					if (sender == null) {
						sender = msgs[i].OriginatingAddress;
					}
					sb.Append(string.Format("SMS From: {0}{1}Body: {2}{1}", msgs[i].OriginatingAddress,
						Environment.NewLine, messageBody));
				}
				if (sender != null)
				{
					Toast.MakeText(context, "IsOrderedBroadcast :" + IsOrderedBroadcast.ToString() + "\n" + sb.ToString(), ToastLength.Long).Show();
				}
				else
				{
					ClearAbortBroadcast();
				}
			}
			catch (Exception ex)
			{
				Toast.MakeText(context, ex.Message, ToastLength.Long).Show();
			}
		}
