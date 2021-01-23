    var meetingDetails = (from p in db.Persons
                          join ts in db.Timeslots on p.PersonID equals ts.PersonID
                          join ar in db.AttendeeResponses on ts.TimeslotID equals ar.TimeslotID
                          join pm in db.PersonMeetings on ar.PersonMeetingID equals pm.PersonMeetingID
                          join m in db.Meetings on pm.MeetingID equals m.MeetingID
                          where m.MeetingID == id
                          && pm.MeetingRole == "Attendee"
                          && ar.Response == "ConfirmedAtVenue"
                          select new MeetingIndexViewmodel
                          {
                              MeetingID = m.MeetingID,
                              AttendeeName = AttendeeNameMatch,
                              ConvenerName = ConvenerNameMatch,
                              OrganiserName = OrganiserNameMatch,
                              StartTime = ts.StartTime != null ? ts.StartTime.ToString() : "null", // or null or string.Empty
                              Duration = ts.Duration.ToString(), // Use this approach if StartTime and Duration can't be null
                              AttendeeResponseID = ar.AttendeeResponseID,
                              Response = ar.Response
                          };
