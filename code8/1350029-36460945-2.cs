    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");
            var resultIntent = new Intent(context, typeof(MainActivity));
            resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            var pending = PendingIntent.GetActivity(context, 0,
                resultIntent,
                PendingIntentFlags.CancelCurrent);
            var builder =
                new Notification.Builder(context)
                    .SetContentTitle(title)
                    .SetContentText(message)
                    .SetSmallIcon(Resource.Drawable.Icon)
                    .SetDefaults(NotificationDefaults.All);
            builder.SetContentIntent(pending);
            var notification = builder.Build();
            var manager = NotificationManager.FromContext(context);
            manager.Notify(1337, notification);
        }
    }
