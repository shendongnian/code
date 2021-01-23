    protected override void Configure ()
    {
        CreateMap<Source.SourceRoot, Destination.DestinationRoot>()
            .ForMember(d => d.ContributesTo, opt => opt.MapFrom(s => s.Organisation));
    
        CreateMap<Source.Organisation, Destination.Organisation>();
        CreateMap<Source.Organisation, Destination.ContributesTo>();
    }
