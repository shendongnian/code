    var OS = System.Environment.OSVersion;
    var platform = OS.Platform;
    var version = OS.Version; // or OS.VersionString
    var servicePack = OS.ServicePack;
    if(platform=="Unix")
    {
    ...
    }
