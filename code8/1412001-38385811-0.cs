    public async Task AttachTypeToMeetingTime(int meetingTimeId,int meetingTypeId)
    {
       await Task.Run(() =>
       {
          SomeMethod(meetingTimeId, meetingTypeId);
            ^^^^^
       });
    }
