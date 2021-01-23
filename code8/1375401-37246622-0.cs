     Java.Lang.Runnable runnable = new Java.Lang.Runnable(() =>
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            });
            new Handler().PostDelayed(runnable, 1000);
