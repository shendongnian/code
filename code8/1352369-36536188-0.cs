    JObject o = JObject.Parse(data);
    JArray players = (JArray)o["response"]["players"];
    if(players.Count > 0){
        int PrivacyLevel = (int)players[0]["communityvisibilitystate"];
        string username = (string)players[0]["personaname"];
        string ProUrl = (string)players[0]["profileurl"];
        if (PrivacyLevel == 3)
        {
            Console.WriteLine("Profile Status: Public");
        }
        else if (PrivacyLevel == 1)
        {
            Console.WriteLine("Profile Status: Private");
        }
    }
    else
    {
        Console.WriteLine("You have typed the Steam ID Incorrectly");
    }
