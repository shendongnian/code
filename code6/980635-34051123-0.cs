    var analyticsInfoType = Type.GetType(
      "Windows.System.Profile.AnalyticsInfo, Windows, ContentType=WindowsRuntime");
    var versionInfoType = Type.GetType(
      "Windows.System.Profile.AnalyticsVersionInfo, Windows, ContentType=WindowsRuntime");
    if (analyticsInfoType == null || versionInfoType == null)
    {
      Debug.WriteLine("Apparently you are not on Windows 10");
      return;
    }
    var versionInfoProperty = analyticsInfoType.GetRuntimeProperty("VersionInfo");
    object versionInfo = versionInfoProperty.GetValue(null);
    var versionProperty = versionInfoType.GetRuntimeProperty("DeviceFamilyVersion");
    object familyVersion = versionProperty.GetValue(versionInfo);
    long versionBytes;
    if (!long.TryParse(familyVersion.ToString(), out versionBytes))
    {
      Debug.WriteLine("Can't parse version number");
      return;
    }
    Version uapVersion = new Version((ushort)(versionBytes >> 48),
      (ushort)(versionBytes >> 32),
      (ushort)(versionBytes >> 16),
      (ushort)(versionBytes));
    Debug.WriteLine("UAP Version is " + uapVersion);
