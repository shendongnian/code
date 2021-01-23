    //This gets called once somewhere when the application is starting.
    public static void Configure()
    {
        //<Source, Destination>
        Mapper.Create<Models.Person, Person>()
            //Additional mappings.
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => new UserName(src.UserName)))
    }
