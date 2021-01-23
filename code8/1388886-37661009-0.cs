    var settings =  System.IO.File.ReadAllText(settingsFile);
    if(settings =="")
    {
        settings = "0,0,0,0,0";
    }
    
    string[] values = settings.Split(',');
