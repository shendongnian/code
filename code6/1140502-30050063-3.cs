    // We need both source objects in order to perform our map
    Mapper.CreateMap<Tuple<DistributionInformation, RouteInformation>, DenormDistributionInfo>()
          .ForMember(d => d.Streetname, o => o.MapFrom(s => s.Item1.Streetname))
          .ForMember(d => d.RouteDescription, o => o.MapFrom(s => s.Item2.RouteDescription))
          .ForMember(d => d.RouteNumber, o => o.MapFrom(s  => s.Item2.RouteNumber));
    // We can use ConstructUsing to pass both our source objects to our map
    Mapper.CreateMap<DistributionInformation, IEnumerable<DenormDistributionInfo>>()
          .ConstructUsing(
              x => x.Routes
                    .Select(y => Mapper.Map<DenormDistributionInfo>(Tuple.Create(x, y)))
                    .ToList());
