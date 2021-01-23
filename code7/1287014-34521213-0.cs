    Mapper.Initialize(config =>
    {
        config.CreateMap<IPerson, PersonDto>()
            .Include<IModelPerson, ModelPersonDto>()
            .ConstructUsing((IPerson person) => 
            {
                if (person is IModelPerson) return Mapper.Map<ModelPersonDto>(person);
    
                throw new InvalidOperationException("Unknown person type: " + person.GetType().FullName);
            })
            ;
    
        config.CreateMap<IModelPerson, ModelPersonDto>();
    });
