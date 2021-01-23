    // Model
    var calendarEvent = new CalendarEvent
        {
            Date = new DateTime(2008, 12, 15, 20, 30, 0),
            Title = "Company Holiday Party"
        };
    // Configure AutoMapper
    Mapper.CreateMap<CalendarEvent, CalendarEventForm>()
        .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
        .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
        .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute));
