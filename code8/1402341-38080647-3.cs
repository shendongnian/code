	Mapper.Initialize(cfg =>
	{
		cfg.CreateMap<EntityAttribute, LeadEntityAttribute>().ForAllMembers(memberConf =>
		{
            memberConf.Condition((ResolutionContext cond) => cond.DestinationType == cond.SourceType);
		});
	}
