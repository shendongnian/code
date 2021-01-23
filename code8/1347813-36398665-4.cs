     cfg.CreateMissingTypeMaps = true;
     cfg.CreateMap<Source, Dest>()
        .ForMember(d => d.UserName, 
            opt => opt.MapFrom(src => userName)
        );
     cfg.CreateMap<AbcEditViewModel, Abc>();
     cfg.CreateMap<Abc, AbcEditViewModel>();
    });
