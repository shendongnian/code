    mapperConfig.CreateMap<CustomerUpdateDto, Customer>()
                    .ForMember(c => c.Locations, m => m.Ignore())
                    .ForMember(c => c.Aliases, opts => opts.Ignore())
                    .ForMember(c => c.Contacts, opts => opts.Ignore())
                    .ForMember(c => c.Activities, opts => opts.Ignore())
                    .AfterMap
                    (
                        (dto, customer) =>
                        {
                            // AHHH! Dependency injection, please ;)
                            IMapper mapper = Container.Current.Resolve<IMapper>();
    
                            dto.Aliases.MapTo<ISet<CustomerAlias>, ISet<CustomerAlias>, CustomerAlias>(customer.Aliases, mapper);
                            dto.Activities.MapTo<ISet<Activity>, ISet<Activity>, Activity>(customer.Activities, mapper);
                            dto.Locations.MapTo<ISet<Location>, ISet<Location>, Location>(customer.Locations, mapper);
                        }
                    )
                    .ForAllMembers(options => options.Condition(src => !src.IsSourceValueNull));
