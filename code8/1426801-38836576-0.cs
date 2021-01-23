    Meeting meeting = new Meeting
    {
        SeminarId = 5 // this would normally be loaded from elsewhere, obviously
    };
    db.Meetings.Add(meeting);
    // meeting.Webinar is still null
    db.Entry(meeting).Reference(m => m.Webinar).Load();
    // meeting.Webinar is populated
