    addTab("home", "Simulator", typeof(SimActivity), Resource.Drawable.ic_action_simulator);
    addTab("estimator", "Estimator", typeof(EstimatorActivity), Resource.Drawable.ic_action_estimator);
    addTab("resources", "Resources", typeof(ResourceActivity), Resource.Drawable.ic_action_resources);
    addTab("search", "Search", typeof(SearchActivity), Resource.Drawable.ic_action_search);
    addTab("about", "About", typeof(AboutActivity), Resource.Drawable.ic_action_about);
    Intent addTab(string keyName, string tabName, Type activityType, int resourceID, params Tuple<string,string>[] extras)
    {
      Intent intent = new Intent(this, activityType);
      intent.AddFlags(ActivityFlags.NewTask);
      intent.PutExtra("key", keyName);
      foreach (Tuple<string,string> pair in extras)
      {
        string key = pair.Item1;
        string value = pair.Item2;
        intent.PutExtra(key, value);
      }
    
      TabHost.TabSpec spec = TabHost.NewTabSpec(keyName);
      spec.SetIndicator(tabName, Resources.GetDrawable(resourceID));
      spec.SetContent(intent);
      TabHost.AddTab(spec);
      return intent;
    }
