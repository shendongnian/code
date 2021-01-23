    String version = "1.0.420.50.0";
    String [] versionArray = version.Split(".");
    String newVersion = "";
    for(int i = 0; i<4; i++)
    {
           newVersion += versionArray[i] + ".";
    }
    newVersion = newVersion.substring(0, newVersion.Size-1);
