    AutoMapper.Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<Tile, TileDto>()
           .ForMember(tileDto => tileDto.Geometry,
                      map => map.MapFrom(tile => tile.Geometry.AsText()));
        cfg.CreateMap<TileDto, Tile>()
           .ForMember(tile => tile.Geometry,
                      map => map.MapFrom(tileDto => DbGeometry.FromText(tileDto.Geometry)));
                
        cfg.CreateMap<Tile, TileDto>();
        cfg.CreateMap<TileDto, Tile>();
    });
