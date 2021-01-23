    Mapper.CreateMap<SomeViewModels, SomeDTO>()               
             .ForMember(dest => dest.Date, o => o.ResolveUsing(Converter));
    private static object Converter(SomeViewModels value)
    {
        DateTime? finalDate = null;
        if (value.Date.HasDate == "N")
        {
            // so it should be null
        }
        else
        {                                   
            finalDate = DateTime.Parse(value.Date.ToString());
        }                               
        return finalDate;
    }
