    public void Post([FromBody] SteamData data)
    {
        if (!Program.settings.UnSub.Contains(steamid))
        {
            SteamID SID = new SteamID(data.SteamId);
            Program.steamFriends.SendChatMessage(SID, EChatEntryType.ChatMsg, System.DateTime.UtcNow + " UTC ( GMT ) : " + data.NoteTitle);
            Thread.Sleep(1000);
            Program.steamFriends.SendChatMessage(SID, EChatEntryType.ChatMsg, data.Message);
        }
    }
