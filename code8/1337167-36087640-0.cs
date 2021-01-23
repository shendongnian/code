    public static T ToViewModel<T,K>(K dbmlClass) 
    {
        return AutoMapper.Mapper.Map<T>(dbmlClass); 
    }
 
    // Register mappings
    public static void ConfigureMappings()
    {
        AutoMapper.Mapper.CreateMap<Character, CharacterViewModel>();
    }
