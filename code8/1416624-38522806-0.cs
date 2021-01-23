    var theMessages = new { 
        NewMessage[] NewMessages = null, 
        OldMessage[] OldMessages = null 
    };
    theMessages = JsonConvert.DeserializeAnonymousType(jsonText, theMessages);
