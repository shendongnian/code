    Event newEvent = new Event()
    {
        Summary = "new event",
        Start = new EventDateTime()
        {
            DateTime = DateTime.Parse("2016-07-11T09:00:00"),
            TimeZone = "America/Los_Angeles"
        },
        End = new EventDateTime()
        {
            DateTime = DateTime.Parse("2016-07-11T10:00:00"),
            TimeZone = "America/Los_Angeles"
        }
    };
    Event createdEvent = service.Events.Insert(newEvent, "primary").Execute();
