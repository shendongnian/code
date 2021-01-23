    var clientDeviceInformation = new EasClientDeviceInformation();
    var operatingSystem = clientDeviceInformation.OperatingSystem;
    if (operatingSystem.Equals("WINDOWS"))
    {
        //add Adcontrol for Windows
        // Programatically create an ad control. This must be done from the UI thread.
        var adControl = new AdControl();
        // Set the application id and ad unit id
        // The application id and ad unit id can be obtained from Dev Center.
        adControl.ApplicationId = "66ad92bf-3c62-4fa8-ad1c-421a56bf0231";
        adControl.AdUnitId = "309519";
    
        // Set the dimensions(windows)
        adControl.Width = 160;
        adControl.Height = 600;
    
        // Add event handlers if you want
        adControl.ErrorOccurred += OnErrorOccurred;
        adControl.AdRefreshed += OnAdRefreshed;
    }
    else
    {
        //add Adcontrol for Windows phone
        var adControl = new AdControl();
    
        // Set the application id and ad unit id
        // The application id and ad unit id can be obtained from Dev Center.
        // See "Monetize with Ads" at https://msdn.microsoft.com/en-us/library/windows/apps/mt170658.aspx
        adControl.ApplicationId = "90b6905b-da20-42fc-bb86-c2b41140fe4e";
        adControl.AdUnitId = "311213";
    
        // Set the dimensions(windows)
        adControl.Width = 300;
        adControl.Height = 50;
    
        // Add event handlers if you want
        adControl.ErrorOccurred += OnErrorOccurred;
        adControl.AdRefreshed += OnAdRefreshed;
    }
