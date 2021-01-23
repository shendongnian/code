    Mapper.CreateMap<SomeViewModels, SomeDTO>().ConvertUsing(Converter);
    private static SomeDTO Converter(SomeViewModelsvalue value)
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
        return new SomeDTO
        {
            Date = finalDate,
            // other properties mapping
        };
    }
