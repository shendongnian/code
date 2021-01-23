        var searchQuery = "chrome";
        var flag = PackageInfoFlags.Activities;
        var apps = PackageManager.GetInstalledApplications(flag);
        foreach(var app in apps)
        {
            try
            {
                var appInfo = PackageManager.GetApplicationInfo(app.PackageName, 0);
                var appLabel = PackageManager.GetApplicationLabel(appInfo);
                if (appLabel.ToLower().Contains(searchQuery.ToLower()))
                {
                    var builder = new AlertDialog.Builder(this);
                    builder.SetTitle("Found it!");
                    builder.SetMessage(appLabel + " installed at: " + app.SourceDir);
                    builder.Show();
                }
            }
            catch (PackageManager.NameNotFoundException e) { continue; }
        }
