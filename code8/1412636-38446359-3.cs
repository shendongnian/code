    // Joining Persons and Timeslots
    var details1 = from p in db.Persons
                   join ts in db.Timeslots on p.PersonID equals ts.PersonID
                   select p;
    // Joining all tables
    var details2 = from p in db.Persons
                   join ts in db.Timeslots on p.PersonID equals ts.PersonID
                   join ar in db.AttendeeResponses on ts.TimeslotID equals ar.TimeslotID
                   join pm in db.PersonMeetings on ar.PersonMeetingID equals pm.PersonMeetingID
                   join m in db.Meetings on pm.MeetingID equals m.MeetingID
                   select p;
    // Joining all tables and filtering
    var details3 = from p in db.Persons
                   join ts in db.Timeslots on p.PersonID equals ts.PersonID
                   join ar in db.AttendeeResponses on ts.TimeslotID equals ar.TimeslotID
                   join pm in db.PersonMeetings on ar.PersonMeetingID equals pm.PersonMeetingID
                   join m in db.Meetings on pm.MeetingID equals m.MeetingID
                   where m.MeetingID == id
                   && pm.MeetingRole == "Attendee"
                   && ar.Response == "ConfirmedAtVenue"
                   select p;
