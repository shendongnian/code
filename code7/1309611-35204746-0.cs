    var dic = chrome.Capabilities.GetCapability("chrome") as Dictionary<string, object>;
    if(dic == null)
    {
        // The capability isn't a dictionary.
    }
    else
    {
        var userDataDir = dic["userDataDir"];
    }
