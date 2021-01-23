    var analyticsInfoType = Type.GetType("Windows.System.Profile.AnalyticsInfo, Windows, ContentType=WindowsRuntime");
    var versionInfoType = Type.GetType("Windows.System.Profile.AnalyticsVersionInfo, Windows, ContentType=WindowsRuntime");
    
    if (analyticsInfoType == null || versionInfoType == null)
    {
        //not on Windows 10
        return;
    }
    
    var versionInfoProperty = analyticsInfoType.GetRuntimeProperty("VersionInfo");
    
    object versionInfo = versionInfoProperty.GetValue(null);
    var versionProperty = versionInfoType.GetRuntimeProperty("DeviceFamilyVersion");
    object familyVersion = versionProperty.GetValue(versionInfo);
    long versionBytes;
    if (!long.TryParse(familyVersion.ToString(), out versionBytes))
    {
        //can't parse version number
        return;
    }
    
    Version DeviceVersion = new Version((ushort)(versionBytes >> 48),
      (ushort)(versionBytes >> 32),
      (ushort)(versionBytes >> 16),
      (ushort)(versionBytes));
    
    if ((ushort)(versionBytes >> 16) == 10586)
    {
        _compositor = new Compositor();
        _root = ElementCompositionPreview.GetElementVisual(myElement);
    }
    else
    {
        //other code
    }
