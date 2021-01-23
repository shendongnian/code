    public async Task<ActionResult> _RoomMeetings(string roomEmail)
    {
        var room = 
            await Settings.informationHolder.FirstOrDefault(m => m.Key == roomEmail).Value;
    } 
