    Event newEvent = new Event()
                {
                    Summary = "Read Awesome Blog posts by Linda ",
                    Location = "1600 Amphitheatre Parkway., Mountain View, CA 94043",
                    Description = "A chance to learn more about Google APIs.",
                    Start = new EventDateTime()
                    {
                        DateTime = DateTime.Parse("2015-09-20T09:00:00-07:00"),
                        TimeZone = "America/Los_Angeles",
                    },
                    End = new EventDateTime()
                    {
                        DateTime = DateTime.Parse("2015-09-20T17:00:00-07:00"),
                        TimeZone = "America/Los_Angeles",
                    },
                    Recurrence = new String[] { "RRULE:FREQ=DAILY;COUNT=2" },
                    Attendees = new EventAttendee[] {
                        new EventAttendee() { Email = "test@test.com" },
                    },
                    Reminders = new Event.RemindersData()
                    {
                        UseDefault = false,
                        Overrides = new EventReminder[] {
                            new EventReminder() { Method = "email", Minutes = 24 * 60 },
                            new EventReminder() { Method = "sms", Minutes = 10 },
                    }
                    }
                };
    
                String calendarId = "primary";
                EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
                Event createdEvent = request.Execute();
