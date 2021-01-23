    var meetings = from m in db.meetings.Include(m=>m.bookings).Take(2)
                    select new MeetingDTO()
                    {
                        meetingid = m.meetingid,
                        meetingname = m.meeting_name,
                        businessname = m.business.name
                        bookingsDTOs = m.bookings.Select(b=>new bookingsDTO()
                                                           {
                                                             bookingid = b.bookingid,
                                                             bookingname = b.name
                                                           })
                    };
        return meetings;
