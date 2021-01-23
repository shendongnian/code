    public async void DefaultLaunch()
    {
       // Path to the file in the app package to launch
       string imageFile = @"images\test.png";
    
       var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);
    
       if (file != null)
       {
          // Launch the retrieved file
          var success = await Windows.System.Launcher.LaunchFileAsync(file);
    
          if (success)
          {
             // File launched
          }
          else
          {
             // File launch failed
          }
       }
       else
       {
          // Could not find file
       }
    }
