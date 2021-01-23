        AutoMapper.Mapper.Initialize(cfg =>
                {
                    // Mapping from database type to client type
                    cfg.CreateMap<StuffToGet, StuffToGetDto>()
                        .ForMember(dst => dst.Id, map => map.MapFrom(src => MySqlFuncs.LTRIM(MySqlFuncs.StringConvert(src.ID))));
                    // Mapping from client type to database type
                    cfg.CreateMap<StuffToGetDto, StuffToGet>()
                        .ForMember(dst => dst.ID, map => map.MapFrom(src => MySqlFuncs.LongParse(src.Id)));
                });
