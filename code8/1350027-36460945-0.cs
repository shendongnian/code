    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");
    
            var pending = PendingIntent.GetActivity(context, 0, new Intent(context, typeof (MainActivity)),
                PendingIntentFlags.UpdateCurrent);
    
            var manager = NotificationManager.FromContext(context);
            var builder =
                new Notification.Builder(context).SetContentIntent(pending)
                    .SetContentTitle(title)
                    .SetContentText(message)
                    .SetAutoCancel(true);
    
            var notification = builder.Build();
            manager.Notify(0, notification);
        }
    }
