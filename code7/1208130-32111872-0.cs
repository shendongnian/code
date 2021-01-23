    var directoryEntry = new DirectoryEntry("IIS://YOURWEBSERVER/W3SVC/AppPools/WebServicesAppPool", USERNAME, PASSWORD);
    // stop the Application Pool
    directoryEntry.Invoke("Stop", null);
    // start the Application Pool
    directoryEntry.Invoke("Start", null);
