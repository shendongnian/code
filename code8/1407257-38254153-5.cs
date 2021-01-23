            public override void OnReceive(Context context, Intent intent)
        {
            Intent Intent = new Intent(context, typeof(MainActivity));
            PendingIntent BuildPendingIntent = PendingIntent.GetActivity(context, 0, Intent, PendingIntentFlags.CancelCurrent);
            manager = NotificationManager.FromContext(context);
            ISharedPreferences pref = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
            ISharedPreferencesEditor editor = pref.Edit();
            string VOn = intent.GetStringExtra("vChecked");
            builder = new NotificationCompat.Builder(context)
                .SetAutoCancel(true)
                .SetContentIntent(BuildPendingIntent)
                .SetContentTitle("Remind Me!")
                .SetTicker("Checklist: Remind Me!")
                .SetContentText("It's time to check your CheckList!")
                .SetSmallIcon(Resource.Drawable.Icon)
                .SetVisibility((int)NotificationVisibility.Public)
                .SetFullScreenIntent(BuildPendingIntent, true)
                .SetPriority((int)NotificationPriority.High);
            //Receive Command by String
            string OnVib = intent.GetStringExtra("vChecked");
            if (OnVib == "On")
            {
                builder.SetDefaults((int)NotificationDefaults.Vibrate);
            }
            else
            {
                builder.SetDefaults((int)NotificationDefaults.Lights);
            }
            manager.Notify(0, builder.Build());
        }
 
