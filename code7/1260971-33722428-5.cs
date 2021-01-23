    AutoMapper.Mapper.CreateMap<EventLogEntry, MyEventLogEntry>()
        .ForMember(dst => dst.InstanceId, opt => opt.MapFrom(src => src.InstanceId))
        .ForMember(dst => dst.Message, opt => opt.MapFrom(src => src.Message))
        .ForMember(dst => dst.GeneratedTime, opt => opt.MapFrom(src => src.TimeGenerated))
        .ForMember(dst => dst.MachineName, opt => opt.MapFrom(src => src.MachineName));
    EventLog log = new EventLog("Application");
    EventLogEntry entry = log.Entries[0];
    MyEventLogEntry my_entry = AutoMapper.Mapper.Map<EventLogEntry, MyEventLogEntry>(entry);
    string json = JsonConvert.SerializeObject(my_entry);
    MyEventLogEntry deserialized_entry = JsonConvert.DeserializeObject<MyEventLogEntry>(json);
