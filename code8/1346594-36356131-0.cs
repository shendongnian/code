            c.CreateMap<MainClass, NewClass>()
                .ForMember(x => x.Candy,
                           opts => opts.MapFrom(
                               src => new CandyObj
                               {
                                   CandyID = src.Candy,
                                   CandyName = src.Candy
                               }
                           ));  
  
