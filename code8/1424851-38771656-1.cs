    var intent = new Intent(context, typeof(MainActivity)); 
    //activity will not be launched if it is already running at the top of the history stack.
    intent.AddFlags(ActivityFlags.SingleTop);   
    //Flag indicating that this PendingIntent can be used only once.
    var pendingIntent = PendingIntent.GetActivity(context, 0
                                                 , intent, PendingIntentFlags.OneShot);
    Notification.Builder builder = new Notification.Builder(this)
                                               .SetContentTitle("My App is Running")
                                               .SetContentText("Show in forground")
                                               .SetSmallIcon(Resource.Drawable.Icon)
                                               .SetContentIntent(pendingIntent);
