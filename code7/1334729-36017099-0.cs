    protected override void OnResume()
        {
            base.OnResume();
            _prefs.GetBoolean("clicked", false);
       }
