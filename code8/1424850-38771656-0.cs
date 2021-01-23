    var intent = new Intent(context, typeof(MainActivity));
    intent.AddFlags(ActivityFlags.SingleTop);
    var pendingIntent = PendingIntent.GetActivity(context, 0
                                                 , intent, PendingIntentFlags.OneShot);
    Notification.Builder builder = new Notification.Builder(this)
                                               .SetContentTitle("My App is Running")
                                               .SetContentText("Show in forground")
                                               .SetSmallIcon(Resource.Drawable.Icon)
                                               .SetContentIntent(pendingIntent);
